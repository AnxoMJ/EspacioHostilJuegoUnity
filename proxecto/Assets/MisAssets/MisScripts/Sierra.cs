using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sierra : MonoBehaviour
{
    public float velocidad;
    // simplemente gira el objeto a la velocidad que se le indique
    void Update()
    {
        transform.Rotate((0),(0),(velocidad));
    }
}
