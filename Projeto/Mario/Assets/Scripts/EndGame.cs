using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EndGame : MonoBehaviour
{

    private PassarInformacao _GameController;
    public static bool Ganhou;

    void Start()
    {
        _GameController = FindObjectOfType(typeof(PassarInformacao)) as PassarInformacao;//iniciamos a variável ao objeto externo
    }
    void OnTriggerEnter2D(Collider2D oi)
    {
        if (oi.tag == "Player")
        {
            Ganhou = true;
            _GameController.numVidas = 5;
            _GameController.numNana = 0;
            _GameController.numRino = 0;
            _GameController.numMoedas = 0;
            _GameController.numPontos = 0;
            Application.LoadLevel("Vitorinha");
        }

    }
}
