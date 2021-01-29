using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] private Image m_introTequifresi = null;
    [SerializeField] private float m_timeToWait = 0.0f;

    // State variables
    private float m_alphaActual = 0.0f;


    void Start()
    {
        Color newColor = m_introTequifresi.color;
        newColor.a = 1.0f;
        m_alphaActual = 1.0f;
        m_introTequifresi.color = newColor;

        StartCoroutine(WaitAndShow());
    }


    IEnumerator WaitAndShow()
    {
        yield return new WaitForSeconds(3);
        while (m_alphaActual > 0f)
        {
            yield return new WaitForSeconds(m_timeToWait);
            Color newColor = m_introTequifresi.color;
            newColor.a = m_alphaActual;
            m_introTequifresi.color = newColor;
            m_alphaActual -= 0.1f;
        }

        m_introTequifresi.enabled = false;
    }

    public void toGame()
    {
        SceneManager.LoadScene("JuegoPrincipal", LoadSceneMode.Single);
    }
}
