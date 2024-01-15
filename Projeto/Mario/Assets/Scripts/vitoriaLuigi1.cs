using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class vitoriaLuigi1 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D oi)
    {
        if (oi.tag == "Player")
        {


            Application.LoadLevel("Fase2Luigi");
        }

    }
}
