using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class nanaMeneger : MonoBehaviour
{
    public int moedas;

    public GameObject LevelMenegerNana;

    public Text moedasT;
   

    void Update()
    {

        moedasT.text = moedas.ToString();
       

    }
}
