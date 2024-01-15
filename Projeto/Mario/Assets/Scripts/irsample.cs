using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class irsample : MonoBehaviour {
    public static bool destroi;
    public Button boi;


    public void mini()
    {
        destroi = true;
        SceneManager.LoadScene("Fase1Mario");

    }
}
