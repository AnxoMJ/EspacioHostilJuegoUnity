using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Simplemente se encarga de  cargar la pantalla del final del juego cuando el jugador lo atraviesa 
public class CargarFinal : MonoBehaviour
{
    private GameMaster gm;

    private void Start()
    {
        gm = FindObjectOfType<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gm.lastCheckpoint = new Vector2(0, 1);
            SceneManager.LoadScene("Final");
        }
    }
}
