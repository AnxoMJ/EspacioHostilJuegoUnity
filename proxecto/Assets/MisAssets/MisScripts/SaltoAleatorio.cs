using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta clase se encarga de hacer que el objeto salte de forma aleatoria, pasándole el mínimo y el máximo de espera y la fuerza de salto.
public class SaltoAleatorio : MonoBehaviour
{
    public Rigidbody2D rb;
    public int fuerzaSalto = 8;
    public int minEspera = 15;
    public int maxEspera = 55;
    public bool debug = false;
    public AudioClip sonSalto;
    private AudioSource audioSource;
    private float timerCountDown;
    System.Random random = new System.Random();

    //Utiliza random.Next, para conseguir un número aleatorio entre los parámetros que se le pasaron.
    void Start()
    {
        timerCountDown = (random.Next(minEspera, maxEspera)) / 10;
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timerCountDown -= Time.deltaTime;
        if (timerCountDown <= 0)
        {
            rb.velocity = Vector2.up * fuerzaSalto;
            audioSource.PlayOneShot(sonSalto, 0.8f);
            timerCountDown = (random.Next(minEspera, maxEspera)) / 10;
            if (debug)
                Debug.Log("Salto " + this.name);
        }
    }
}
