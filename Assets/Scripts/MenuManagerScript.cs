using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject m_PauseMenuGUI = null;

    private bool m_Stopped = false;

    private void Awake()
    {
        m_PauseMenuGUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Show Menu if not showing
            if (!m_Stopped)
            {
                // Stop time
                Time.timeScale = 0f;
                m_Stopped = true;
                // Show menu scene
                m_PauseMenuGUI.SetActive(true);
            }
            else // else show
            {
                // Resume time
                Time.timeScale = 1f;
                m_Stopped = false;
                // Close menu scene
                m_PauseMenuGUI.SetActive(false);

            }

        }
    }

    public void ResumePlaying()
    {
        // Resume time
        Time.timeScale = 1f;
        m_Stopped = false;
        // Close menu scene
        m_PauseMenuGUI.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}