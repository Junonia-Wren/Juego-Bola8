using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    // Start is called before the first frame update
       public GameObject jugador;
        private Vector3 offset; 
    void Start()
    {
    //referencia seguir aljugador
     offset = transform.position - jugador.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    transform.position = jugador.transform.position + offset; 
    }
}
