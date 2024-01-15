using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    PAUSE,
    GAMEPLAY,
    INFO,
    STATUS
}

public class PassarInformacao : MonoBehaviour
{
    public GameState currentState; //estado atual do JOGO
    private PassarInformacao _GameController;
     //Pause
    public Button firstPainelPause;
    public Button firstPainelINFO;
    public Button firstPainelStatus;


    //--------------------------------
    

    public  int numVidas;
    public  int numNana;
    public  int numRino;
    public  int numMoedas;
    public  int numPontos;



    public GameObject levelMenegerVida;
    public GameObject levelMenegerNana;
    public GameObject levelMeneger;
    public GameObject levelMenegerRino;


    public GameObject painelPause;
    public GameObject painelInfo;
    public GameObject painelStatus;

    void Start()
    {

        if (mario.morte == true || EndGame.Ganhou)
        {
           
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            colocaValores();
            guardaValores();
        }
        painelPause.SetActive(false);//inicia o jogo com o painelPause desativado
        painelInfo.SetActive(false);//inicia o jogo com o painelPause desativado
        painelStatus.SetActive(false);//inicia o jogo com o painelPause desativado
    }
    private void Update()
    {
        colocaValores();
        guardaValores();

        if (Input.GetButtonDown("Cancel") && currentState != GameState.INFO && currentState != GameState.STATUS)//quando pressionar a tecla ESC abre/fecha o menu
        {
            pauseGame();
        }
    }



    void colocaValores()
    {
        levelMenegerVida.GetComponent<VidaMenager>().moedas = numVidas;
        levelMenegerNana.GetComponent<nanaMeneger>().moedas = numNana;
        levelMenegerRino.GetComponent<DouradoManager>().moedas = numRino;
        levelMeneger.GetComponent<LevelManeger>().moedas = numMoedas;
        levelMeneger.GetComponent<LevelManeger>().pontos = numPontos;





    }

    void guardaValores()
    {
        levelMenegerVida.GetComponent<VidaMenager>().moedas = numVidas;
        levelMenegerNana.GetComponent<nanaMeneger>().moedas = numNana;
        levelMenegerRino.GetComponent<DouradoManager>().moedas = numRino;
        levelMeneger.GetComponent<LevelManeger>().moedas = numMoedas;
        levelMeneger.GetComponent<LevelManeger>().pontos = numPontos;

    }

    public void pauseGame()
    {
        bool pauseState = painelPause.activeSelf;
        pauseState = !pauseState;
        painelPause.SetActive(pauseState);
        switch (pauseState)
        {
            case true:
                Time.timeScale = 0;
                changeState(GameState.PAUSE);
                firstPainelPause.Select();
                break;
            case false:
                Time.timeScale = 1;
                changeState(GameState.GAMEPLAY);
                break;
        }
    }
   

    public void changeState(GameState newState)
    {
        currentState = newState;
    }

    public void btnItensDown()
    {
        painelPause.SetActive(false);
        painelInfo.SetActive(true);
        painelStatus.SetActive(false);
        changeState(GameState.INFO);
        firstPainelINFO.Select();
    }

    public void btnStatusDown()
    {
        painelPause.SetActive(false);
        painelInfo.SetActive(false);
        painelStatus.SetActive(true);
        changeState(GameState.STATUS);
        firstPainelStatus.Select();
    }

    public void fecharPainel()
{
    painelInfo.SetActive(false);
    painelStatus.SetActive(false);

//outros paineis quando estiverem prontos
    painelPause.SetActive(true);

changeState(GameState.PAUSE);
        firstPainelPause.Select();
}

    public void fecharPause()
    {
        painelInfo.SetActive(false);
        painelStatus.SetActive(false);

        //outros paineis quando estiverem prontos
        painelPause.SetActive(false);
        Time.timeScale = 1;
        changeState(GameState.GAMEPLAY);

    }


}
 