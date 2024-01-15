using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moeda : MonoBehaviour {

    private PassarInformacao _GameController;

    void Start()
    {
        _GameController = FindObjectOfType(typeof(PassarInformacao)) as PassarInformacao;//iniciamos a variável ao objeto externo
    }


    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
            {
            gameObject.GetComponent<AudioSource>().Play();
            _GameController.numMoedas += 1;
            _GameController.numPontos += 10;
            Destroy(gameObject);
        }
    }

   
}
