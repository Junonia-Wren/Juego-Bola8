using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ScriptMenuInicial : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void Salir()
    {
        Debug.Log("SSALIENDOOO");
        Application.Quit();
        
    }
}
