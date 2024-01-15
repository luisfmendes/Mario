using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DouradoManager : MonoBehaviour
{

    public int moedas;

    public GameObject levelMenegerRino;

    public Text moedasT;


    void Update()
    {

        moedasT.text = moedas.ToString();


    }
}
