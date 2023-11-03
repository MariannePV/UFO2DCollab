using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();     //Sortir del joc
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);      //Reiniciar el joc
    }
}
