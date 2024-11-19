using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScriptGameManager : MonoBehaviour
{
    public int vidas = 3; 
    public float tiempo = 0; 
    public int monedas = 3;
    public bool isLive= true;

    
    
    void Start()
    {
        
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("SALIENDO DEL NIVEL 1"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
