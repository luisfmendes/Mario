using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ganhalua : MonoBehaviour
{
    public GameObject mario2;
   
    mario mario;
    public bool corno; 

    void Update()
    {
        if (corno == true)
        {
            corno = false;
            mario2.GetComponent<mario>().vida = mario2.GetComponent<mario>().vida + 4;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            gameObject.GetComponent<AudioSource>().Play();
            corno = true;
            
          
        }
    }

  
}
