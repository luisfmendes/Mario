using System.Collections;
using System.Collections.Generic;
using UnityEngine;



 
public class mario : MonoBehaviour
{
    private PassarInformacao _GameController;

    public float velocidade;
    public float ForcaDoPulo;
    public bool noChao = true;
    public bool girou = false;
    public AudioSource pulo;
    public AudioSource pulogirando;
    public Animator anim;
    public Rigidbody2D rb2d;
    public float velomax;
    public bool correndo;
    

    public Transform Mario;


    public GameObject BalaPrefab;
    public Transform ShotSpawner;

    public GameObject NanaPrefab;
    public Transform ShotSpawnerNana;

    public float fireRate = 0.5f;
    public float nextFire;

    public int vida;
    public bool morreu;
    public Transform Inicio;

    public string morrido;


    
    public static bool morte;
    void Start()
    {

        _GameController = FindObjectOfType(typeof(PassarInformacao)) as PassarInformacao;

        vida = _GameController.numVidas;



        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

    }
    void Update()
    {

        if (_GameController.currentState != GameState.GAMEPLAY)
        {
            return;
        }
        if (morreu == true)
        {

            _GameController.numVidas = _GameController.numVidas - 1;
            morreu = false;
            this.gameObject.transform.position = new Vector3(Inicio.transform.position.x,Inicio.transform.position.y,Inicio.transform.position.z);
            
        }
        if (_GameController.numVidas < 1)
        {
           _GameController.numVidas = 5;
            _GameController.numNana = 0;
            _GameController.numRino = 0;
            _GameController.numMoedas = 0;
            _GameController.numPontos = 0;
            morte = true;
            morreu = true;
            Application.LoadLevel("Morte");
        }


        anim.SetBool("NoChao", noChao);
        anim.SetBool("Correndo", correndo);

        anim.SetFloat("Velocidade", Mathf.Abs(rb2d.velocity.x));

        //ele vai andar para direita
        if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
        {

            transform.localScale = new Vector3(-1, 1, 1);
            if ((rb2d.velocity.magnitude < velomax) && (!anim.GetBool("Abaixado")) && (!anim.GetBool("parado")))

                rb2d.AddForce(Vector2.right * velocidade);
        }

        //ele vai andar para a esquerda
        if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.localScale = new Vector3(1, 1, 1);
            if ((rb2d.velocity.magnitude < velomax) && (!anim.GetBool("Abaixado")) && (!anim.GetBool("parado")))
                rb2d.AddForce(Vector2.left * velocidade);
        }

        //pular
        if (Input.GetButtonDown("Jump"))
        {
            if (noChao)
            {
                rb2d.AddForce(Vector2.up * ForcaDoPulo);
                pulo.Play();
            }
        }

        //abaixar
        if (noChao)
        {
            if (Input.GetButton("Abaixar"))
            {

                anim.SetBool("Abaixado", true);
                BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>();
                box.size = new Vector2(box.size.x, 0.1096337f);
                box.offset = new Vector2(box.offset.x, -0.02671149f);

            }
            else
            {
                anim.SetBool("Abaixado", false);
                BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>();
                box.size = new Vector2(box.size.x, 0.1430836f);
                box.offset = new Vector2(box.offset.x, -0.009986544f);
            }
        }
        //girar
        if (Input.GetButtonDown("Girar"))
        {
            if (noChao)
            {
                rb2d.AddForce(Vector2.up * ForcaDoPulo);
                pulogirando.Play();
                girou = true;

            }
        }

        //correr
        if (Input.GetButton("Correr"))
        {
            if (noChao)
            {
                velocidade = 6.5f;
                velomax = 3;
                correndo = true;

            }
        }
        else
        {
            if ((noChao) && (Mathf.Abs(rb2d.velocity.x) >= 0.5f) && (correndo))
            {
                anim.SetBool("parado", true);

            }
            else
            {
                if ((noChao) && (Mathf.Abs(rb2d.velocity.x) < 0.3f) && (correndo))
                {
                    anim.SetBool("parado", false);
                    correndo = false;

                }
                velocidade = 5;
                velomax = 2;
            }
        }



        //morrer
        if (transform.position.y <= -8.91f)
        {
            _GameController.numVidas = 5;
            _GameController.numNana = 0;
            _GameController.numRino = 0;
            _GameController.numMoedas = 0;
            _GameController.numPontos = 0;
            morte = true;
            Application.LoadLevel("morte");
        }



        //atirar

        if (Input.GetKeyDown(KeyCode.E) && Time.time > nextFire)
        {
            anim.SetBool("bolinhafogo", true);
            nextFire = Time.time + fireRate;
            GameObject tempBullet = Object.Instantiate(BalaPrefab, ShotSpawner.position, ShotSpawner.rotation);

            if (Mario.transform.localScale.x > 0)
            {
                tempBullet.transform.eulerAngles = new Vector3(180, 0, 180);

            }

        }

        //atirar banana
        if (_GameController.numNana > 0)
        {


            if (Input.GetKeyDown(KeyCode.R) && Time.time > nextFire)
            {
                anim.SetBool("bolinhafogo", true);
                nextFire = Time.time + fireRate;
                GameObject tempBullet = Object.Instantiate(NanaPrefab, ShotSpawnerNana.position, ShotSpawnerNana.rotation);

                if (Mario.transform.localScale.x > 0)
                {
                    tempBullet.transform.eulerAngles = new Vector3(180, 0, 180);

                }
                _GameController.numNana--;
            }
        }
        //-----------------------------------------------------------------------------------

        if (_GameController.numRino >= 2)
        {
            _GameController.numVidas++;

            _GameController.numRino = _GameController.numRino - 2;
        }

        if (_GameController.numPontos >= 1000)
        {
            _GameController.numVidas++;
            _GameController.numPontos = _GameController.numPontos - 1000;
        }





    }

  
}



