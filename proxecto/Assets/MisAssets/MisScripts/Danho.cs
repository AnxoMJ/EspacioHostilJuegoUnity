using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script se encarga de quitarle vida al jugador
public class Danho : MonoBehaviour
{
    public int cantDanho;
    public float espera;
    public Corazones cor;
    float timerCountDown;
    bool estaTocando = false;

    private void Start()
    {
        timerCountDown = espera;
    }
    void Update()
    {
        // Cuenta cuanto tiempo esta tocando el jugador
        if (estaTocando == true)
        {
            timerCountDown -= Time.deltaTime;
            if (timerCountDown < 0)
            {
                timerCountDown = 0;
            }
        }
    }

    //Cuando el jugador choca se le quita salud
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            cor.salud -= cantDanho;
            Debug.Log("toca");
            estaTocando = true;
        }
    }

    // Si el jugador sigue tocando, se le resta salud cada x tiempo definido
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && estaTocando == true)
        {
            if (timerCountDown <= 0)
            {
                Debug.Log("se queda");
                timerCountDown = espera;
                cor.salud -= cantDanho;
            }
        }
    }

    //Si no esta chocando se actualiza a false
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Sale");
            estaTocando = false;
        }
    }
}
