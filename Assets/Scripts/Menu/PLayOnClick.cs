using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLayOnClick : MonoBehaviour 
{
 public void LoadScene(string Main)
    {
        SceneManager.LoadScene(Main);
    }
}
