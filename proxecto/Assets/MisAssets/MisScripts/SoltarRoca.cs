using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cuando el jugador atraviesa el objeto, la roca se activa y cae.
public class SoltarRoca : MonoBehaviour
{
    public Rigidbody2D rb;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Run Forest, Run!!!");
            //este método activa las físicas de la roca(gravedad,masa, etc) y esta cae.
            rb.WakeUp();
        }
    }
}
