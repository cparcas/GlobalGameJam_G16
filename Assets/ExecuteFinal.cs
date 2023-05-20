using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class ExecuteFinal : MonoBehaviour
{
    [SerializeField]
    public GameObject[] sprites;

    [SerializeField]
    public GameObject player;

    [SerializeField]
    public Camera camara;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindGameObjectWithTag("GlobalLigth").GetComponent<Light2D>().intensity = 1;
        camara.orthographicSize = 30;
        player.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
        StartCoroutine(ChangeAlpha());
    }

    IEnumerator ChangeAlpha()
    {
        foreach (var item in sprites)
        {
            item.SetActive(true);
            yield return new WaitForSeconds(1); 

        }
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Creditos", LoadSceneMode.Single);
        yield return 0;
    }
}
