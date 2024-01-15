using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barril : MonoBehaviour {

   public static bool morreu;
    private PassarInformacao _GameController;

    void Start()
    {
        _GameController = FindObjectOfType(typeof(PassarInformacao)) as PassarInformacao;//iniciamos a variável ao objeto externo
    }

    // Update is called once per frame
    void Update () {

        transform.Translate(0, 1 * Time.deltaTime, 0);
	}

    void OnTriggerEnter2D(Collider2D oi)
    {
        if (oi.tag == "Player")
        {
            
            _GameController.numNana = 0;
           _GameController.numMoedas = 0;
           _GameController.numPontos = 0;
            _GameController.numVidas = 5;
           _GameController.numRino = 0;

            Application.LoadLevel("morte");
        }
    }
    
}
