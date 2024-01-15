using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MudarCenas : MonoBehaviour
{
    
    public Button boi;
    public string local;

    public void mini()
    {
        
        SceneManager.LoadScene(local);

    }
}
