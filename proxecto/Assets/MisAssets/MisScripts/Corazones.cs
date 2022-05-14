using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Esta clase, se encarga de gestionar el sistema de vida del jugador.
public class Corazones : MonoBehaviour
{
    public int salud;
    public int cantidadCorazones;
    public Image[] corazones;
    public Sprite corazonLleno;
    public Sprite corazonVacio;
    public GameObject menuMuerte;
    private int acmVida;
    Animator m_Animator;
    bool danho = false;
    float timerCountDown = 0.1f;
    //saco el animator del personaje
    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        acmVida = salud;
    }
    //si su salud es 0 o menor(está muerto),pausa el juego y deja al jugador con la animación de muerte
    private void Update()
    {
        if (salud <= 0)
        {
            m_Animator.Play("Muerto", 0, 0.25f);
            menuMuerte.SetActive(true);
            Time.timeScale = 0f;
            danho = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        //si tenemos mas salud que corazones, deja la salud igual que los máximos corazones que tengamos deiponibles
        if (salud > cantidadCorazones)
            salud = cantidadCorazones;
        for (int i = 0; i < corazones.Length; i++)
        {
            //Aparecen marcados los corazones que estan "sanos", segun la salud total que tengamos
            if (salud > i)
                corazones[i].sprite = corazonLleno;
            else
                corazones[i].sprite = corazonVacio;
            //Muestra solo los corazones que tenemos disponibles
            if (i < cantidadCorazones)
                corazones[i].enabled = true;
            else
                corazones[i].enabled = false;
        }
        //si su salud baja, indica que sufre daño
        if (acmVida > salud)
        {
            danho = true;
        }
        acmVida = salud;
        //se encarga de mostrar la animación de daño durante el tiempo indicado
        if (danho == true)
        {
            timerCountDown -= Time.deltaTime;
            if (timerCountDown > 0)
            {
                m_Animator.Play("Danho", 0, 0);
            }
            else
            {
                danho = false;
                m_Animator.Play("Quieto", 0, 0);
                timerCountDown = 0.1f;
            }
        }
    }
}
