using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agua : MonoBehaviour {
    public GameObject volta;

    public GameObject spawn;
 
    public GameObject mario2;
    public bool boi;
    mario mario;
    
	// Use this for initialization
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            mario2.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z);
            mario2.GetComponent<mario>().morreu = true;

        }
      
    }
}
