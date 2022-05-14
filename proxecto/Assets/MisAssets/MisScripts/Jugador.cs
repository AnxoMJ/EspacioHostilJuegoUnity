using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

///Esta clase es la más importante de todas, se encarga del movimiento del jugador y de otros parámetros relacionados con el

public class Jugador : MonoBehaviour
{
    public int rapidez=5;
    public Animator animator;
    public static Vector3 posicionPersonaje;
    public Transform posPies;
    public float checkRadio;
    public LayerMask tipoSuelo;
    public float fuerzaSalto;
    public float timepoSalto;
    public static bool estaSaltando=false;
    public int maxSaltos=2;
    public int vBonusVida=99999;
    public ParticleSystem particulas;
    public TextMeshProUGUI TxMonedas;
    public Corazones cor;
    public  AudioClip sonMoneda;
    public  AudioClip sonDanho;
    public  AudioClip sonSaltar;
    public  AudioClip sonAndando;
    public bool pausado=false;
    private  AudioSource audioSource;
    private int monedasRecogidas=0;
    private int bonusVida=0;
    private int acVida;
    private float timerSalto;
    private  float movInput=0;
    private Rigidbody2D rb;
    private bool tocaSuelo;
    private static float vHorizontal=0;
    private static float vVertical=0;
    private int nSaltos=0;
    private ParticleSystem.EmissionModule em;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Time.timeScale= 1f;
        rb = GetComponent<Rigidbody2D>();
        em = particulas.emission;
        acVida=cor.salud;
        estaSaltando=false;
        animator.SetBool("Saltando",estaSaltando);
    }

    private void FixedUpdate() {
        //si el jugador está muerto o se está en pausa no hace nada
        if(cor.salud<=0||pausado)
            return;
        //variable con el valor del eje Horizontal y vertical(pulsado)
        vHorizontal=Input.GetAxis("Horizontal");
        vVertical=Input.GetAxis("Vertical");
        //Le pasa el parámetro "Horizontal" y el valor actual del eje
        animator.SetFloat("Horizontal",vHorizontal);
        //movimiento rn horizontal
        Vector3 horizontal = new Vector3(vHorizontal,0.0f,0.0f);
        transform.position=transform.position+horizontal*Time.deltaTime*rapidez;
}
    // Update is called once per frame
    void Update()
    {
        //si el jugador está muerto o se está en pausa no hace nada
        if(cor.salud<=0||pausado)
            return;
        //Se encarga de desactivar las partículas si el jugador está quieto
        if (posicionPersonaje==transform.position)
            em.enabled=false;
        else
            em.enabled=true;
            
        //Se encarga de rotar al personaje al cambiar de rirección(usa un efecto espejo)
        movInput = Input.GetAxisRaw("Horizontal");
       // rb.velocity = new Vector2(movInput * rapidez,rb.velocity.y);
        if(movInput>0){
            transform.eulerAngles = new Vector3(0,0,0);
            if (!audioSource.isPlaying&&!estaSaltando){
                audioSource.clip=sonAndando;
                //audioSource.Play();
                audioSource.PlayOneShot(sonAndando,0.35f);
            }
        }else if (movInput < 0){
            transform.eulerAngles = new Vector3(0,180,0);
            //si no se esta reproduciondo, reproduce el sonido de caminar
            if (!audioSource.isPlaying&&!estaSaltando){
                audioSource.clip=sonAndando;
                //audioSource.Play();
               audioSource.PlayOneShot(sonAndando,0.35f);
            }
        }
        //permite hacer varios saltos
        //si detecta que se toca el suelo, tocasuelo es verdadero
        tocaSuelo = Physics2D.OverlapCircle(posPies.position,checkRadio,tipoSuelo);
        if (tocaSuelo)
            nSaltos=0;
        if( ((nSaltos<maxSaltos)||(tocaSuelo == true))&&(Input.GetButtonDown("Saltar"))){
            nSaltos++;
            estaSaltando=true;
            if (tocaSuelo)
            timerSalto=timepoSalto;
            rb.velocity = Vector2.up * fuerzaSalto;
        }
        //se encarga de hacer un salto largo, mientras se mantenga pulsado el botón
        if(Input.GetButton("Saltar")&&estaSaltando==true){
            if(timerSalto > 0){
                rb.velocity = Vector2.up * fuerzaSalto;
                timerSalto -= Time.deltaTime;
                //si no esta cargado el sonido de saltar, lo carga(no es necesario para reproducir, pero lo uso para saber que esta sonando)
                if (audioSource.clip!= sonSaltar)
                    audioSource.Pause();
                if (!audioSource.isPlaying){
                    audioSource.clip=sonSaltar;
                    audioSource.PlayOneShot(sonSaltar,0.5f);}
            }else{
                nSaltos++;
                estaSaltando=false;
            }
        }
        //Al soltar el boton cambia el estado de saltando a false
        if(Input.GetButtonUp("Saltar")){
            estaSaltando=false;
        }
        animator.SetBool("Saltando",estaSaltando);
        //actualiza la variable posición segun su nueva posición(para que la use la cámara u otro elemento)
        posicionPersonaje=transform.position;
        //aumenta la vida máxima si el jugador consigue cierta cantidad de monedas;
        if (bonusVida>=vBonusVida){
            cor.cantidadCorazones++;
            cor.salud++;
            bonusVida=0;
        }
        if (acVida>cor.salud)
            audioSource.PlayOneShot(sonDanho,1f);

        acVida=cor.salud;
    }
    //Si tocas una moneda, se añade y si es un bonus de salud, te sube la vida
     private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="Moneda"||other.tag=="Salud"){
            GameObject.Destroy(other.gameObject);
                if (other.tag=="Moneda"){
                    monedasRecogidas++;
                    bonusVida++;
                    TxMonedas.text=monedasRecogidas.ToString();
                }else {
                    cor.salud++;
                }
            audioSource.PlayOneShot(sonMoneda,0.7f);
            Debug.Log("Moneda obtenida");
        }
     }
}