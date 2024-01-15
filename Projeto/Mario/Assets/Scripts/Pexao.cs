using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pexao : MonoBehaviour
{
    public float speed = 3;
    Vector2 dir = Vector2.right;
    public float upforce = 800;
    public GameObject volta, mario2;
    public bool boi;
    mario mario;





    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = dir * speed;

    }
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name != "Mario")
        {
            transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);
            dir = new Vector2(-1 * dir.x, dir.y);
        }
        if (coll.gameObject.name == "Mario")
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Mario")
        {
            mario2.GetComponent<mario>().morreu = true;

        }
    }
   
}
