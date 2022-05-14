using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sigue al personaje en función de su posición, copiando la posición del mismo
public class SeguirPersonajeCamara : MonoBehaviour
{
    public GameObject fondo;
    private void Start()
    {
        //GetComponent<Renderer>().bounds.size;
    }
    //Establece las coordenadas de la cámara según las que tenga el personaje
    private void FixedUpdate()
    {
        //esta parte para pc
            //GetComponent<Renderer>().bounds.size;
            //transform.position=new Vector3(Jugador.posicionPersonaje.x,Jugador.posicionPersonaje.y+2,-10.0f);
        //Esta parte es para android y pc
        transform.position = new Vector3(JugadorAndroid_PC.posicionPersonaje.x, JugadorAndroid_PC.posicionPersonaje.y + 2, -10.0f);
    }
}
