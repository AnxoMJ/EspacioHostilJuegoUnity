using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta clase rota el péndulo de un lado al otro, según la velicidad y el ángulo aportado.
public class Pendulo : MonoBehaviour
{
    public float velocidad;
    public float maxAngulo;
    public bool izquierda = true;
    public bool derecha = false;
    public AudioClip sonPendulo;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //se encarga de que el objeto se mueva de izquierda a derecha dentro del rango y velocidad especificados
    void FixedUpdate()
    {
        //retorna el valor negativo del ángulo
        float angulo = transform.localEulerAngles.z;
        angulo = (angulo > 180) ? angulo - 360 : angulo;
        //Simplemente se mueve de izquierda a derecha
        if (izquierda)
        {
            transform.Rotate((0), (0), (velocidad * -1));
            if ((angulo) < maxAngulo * -1)
            {
                //Debug.Log("cambio Derecha");
                derecha = true;
                izquierda = false;
                audioSource.PlayOneShot(sonPendulo, 0.4f);
            }
        }
        else if (derecha)
        {
            transform.Rotate((0), (0), (velocidad));
            if ((angulo) > maxAngulo)
            {
                //Debug.Log("cambio Izquierda");
                derecha = false;
                izquierda = true;
                audioSource.PlayOneShot(sonPendulo, 0.4f);
            }
        }
    }
}
