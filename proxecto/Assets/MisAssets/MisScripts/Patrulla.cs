using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simplemente mueve el objeto de izquierda a derecha según la velocidad indicada y la distancia.
public class Patrulla : MonoBehaviour
{
    public float velocidad = 5f;
    public float distanciaIzquierda = 5f;
    public float distanciaDerecha = 5f;
    public bool debug = false;
    public bool izquierda = true;
    public bool derecha = false;
    Vector3 coordenadaOG;
    Vector3 posicion;
    bool inicial = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //se encarga de que el objeto se mueva de izquierda a derecha dentro del rango y velocidad especificados
    void FixedUpdate()
    {
        //la primera vez que se inicia guarda las cordenadas originales del objeto
        if (inicial)
        {
            coordenadaOG = posicion = transform.position;
            inicial = false;
        }
        if (izquierda)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(-velocidad * Time.deltaTime, rb.velocity.y);
            if (transform.position.x < (coordenadaOG.x - distanciaIzquierda))
            {
                izquierda = false;
                derecha = true;
            }
            if (debug)
                Debug.Log("izquierda " + posicion + " - " + coordenadaOG);
        }
        else if (derecha)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.velocity = new Vector2(velocidad * Time.deltaTime, rb.velocity.y);
            if (transform.position.x > (distanciaDerecha + coordenadaOG.x))
            {
                izquierda = true;
                derecha = false;
            }
            if (debug)
                Debug.Log("derecha " + posicion + " - " + coordenadaOG);
        }
    }
}
