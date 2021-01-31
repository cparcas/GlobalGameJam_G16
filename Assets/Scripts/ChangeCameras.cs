using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class ChangeCameras : MonoBehaviour
{
    [SerializeField]
    InputManager input;

    [SerializeField]
    public float transitionDuration;
    
    [SerializeField]
    Timer timer;

    [SerializeField]
    public float nearest;
    [SerializeField]
    Camera camera2; 
    [SerializeField]
    Camera camera1;
    [SerializeField]
    public float intensidadGlobal;
    [SerializeField]
    public float defaultvalueLigth;
    [SerializeField]
    public float defaultvalueNear;
    public bool globalCamera;
    [SerializeField]
    public Transform puntoFinal;

    private float finnM;

    [SerializeField]
    public Image found;


    private bool puesbools=false;
    public void Start()
    {
        input.canMove = true;
        timer.canChange = true;
        timer.lessTime = true;
        this.globalCamera = true;
        camera1.enabled = true;
        camera2.enabled = false;
    }

    public void Update()
    {
        if (globalCamera) {
            this.transform.position = new Vector3(input.Player1.transform.position.x, input.Player1.transform.position.y, this.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.E) && timer.canChange)
        {
 
            timer.lessTime = !timer.lessTime;
            input.canMove = !input.canMove;
            globalCamera = !globalCamera;
            camera2.enabled = !camera2.enabled;  
            camera1.enabled = !camera1.enabled;
            if (globalCamera)
            {
                StartCoroutine(Transition(defaultvalueNear, defaultvalueLigth , true));
                puesbools = true;
                //if (puesbools)
                //{
                //    StartCoroutine(Transition2(input.Player1.transform));
                //    puesbools = false;
                //}

            }
            else
            {
                StartCoroutine(Transition(nearest, intensidadGlobal, false));
                //puesbools = true;
                //if (puesbools)
                //{
                //    StartCoroutine(Transition2(puntoFinal));
                //    puesbools = false;
                //}
            }
        }
       
    }

    IEnumerator Transition(float value, float intensity, bool isGlobal)
    {
        float iniii = 0;
        float fin = 0.8f;
        if (isGlobal) {
            iniii = 0.8f;
            fin = 0;
        }
        //float startingPosX = this.transform.position.x;
        //float startingPosY = this.transform.position.y;
        float t = 0.0f;
        //float ini = camera2.orthographicSize;
        float ints = GameObject.FindGameObjectWithTag("GlobalLigth").GetComponent<Light2D>().intensity;
        Color c = found.color;
        //transform.position = new Vector3(ttt.position.x, ttt.position.y, -10);
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / transitionDuration);
            c.a = Mathf.Lerp(iniii, fin, t);
            found.color = c;
            //camera2.orthographicSize = Mathf.Lerp(ini, value, t);
            GameObject.FindGameObjectWithTag("GlobalLigth").GetComponent<Light2D>().intensity = Mathf.Lerp(ints, intensity, t);   
            yield return 0;
        }
        //transform.position = new Vector3(startingPosX, startingPosY, -10);
    }
    //IEnumerator Transition2()
    //{
    //    float t = 0.0f;
    //    float startingPosX = this.transform.position.x;
    //    float startingPosY = this.transform.position.y;
    //    while (t < 1.0f)
    //    {
    //        t += Time.deltaTime * (Time.timeScale / transitionDuration);
    //        float x = Mathf.Lerp(startingPosX, ttt.position.x, t);
    //        float y = Mathf.Lerp(startingPosY, ttt.position.y, t);
    //        this.transform.position = new Vector3(x, y, -10);
    //        yield return 0;
    //    }
    //}

}