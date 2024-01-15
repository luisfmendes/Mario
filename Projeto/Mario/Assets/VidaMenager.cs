using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaMenager : MonoBehaviour
{
    public int moedas;
    
    
    
   
    private PassarInformacao _GameController;

    public Text moedasT;

    void Start()
    {
        _GameController = FindObjectOfType(typeof(PassarInformacao)) as PassarInformacao;//iniciamos a variável ao objeto externo
       
    }

    void Update()
    {

        moedasT.text = moedas.ToString();
       moedas= _GameController.numVidas;


    }
}
