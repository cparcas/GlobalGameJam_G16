using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public void toGame()
    {
        SceneManager.LoadScene("MainGameCarlos", LoadSceneMode.Single);
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
