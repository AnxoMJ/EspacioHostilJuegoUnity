using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//establece las coordenadas del checkpoint al GameMaster(es un objeto que permanece intacto cuando se recarga el nivel, porlo que se pueden sacar datos del)
public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    public GameObject txPuntoControl;
    public int duracion;
    private float timerCountDown;
    private bool activo;

    private void Start()
    {
        gm = FindObjectOfType<GameMaster>();
    }

    //muestra el mensaje de que se activa el punto de control.
    private void Update()
    {
        timerCountDown -= Time.deltaTime;
        if (timerCountDown <= 0 && activo)
        {
            txPuntoControl.SetActive(false);
            activo = false;
        }
    }

    //cuando el jugador lo atraviesa, guarda las coordenadas del checkpoint en el GameMaster(objeto que perdura y gestiona el punto de reaparición del jugador)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Checkpoint " + other.tag + " Activado");
            activo = true;
            txPuntoControl.SetActive(true);
            timerCountDown = duracion;
            gm.lastCheckpoint = transform.position;
        }
    }
}
