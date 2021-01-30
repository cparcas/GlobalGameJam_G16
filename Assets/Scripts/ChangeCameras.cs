using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ChangeCameras : MonoBehaviour
{
    [SerializeField]
    InputManager input;

    [SerializeField]
    public Transform target;

    [SerializeField]
    public float transitionDuration;
    
    [SerializeField]
    Timer timer;

    [SerializeField]
    public float nearest;

    [SerializeField]
    public float intensidadGlobal;
    [SerializeField]
    public float defaultvalueLigth;
    [SerializeField]
    public float defaultvalueNear;
    public bool globalCamera;
    [SerializeField]
    public Transform puntoFinal;

    public void Start()
    {
        input.canMove = true;
        timer.canChange = true;
        timer.inciarContador = false;
        this.globalCamera = true;
    }

    public void Update()
    {
        if (globalCamera) {
            this.transform.position = new Vector3(input.Player1.transform.position.x, input.Player1.transform.position.y, this.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.E) && timer.canChange)
        {
            timer.inciarContador = !timer.inciarContador;
            input.canMove = !input.canMove;
            globalCamera = !globalCamera;
            if (globalCamera)
            {
                StartCoroutine(Transition(defaultvalueNear, defaultvalueLigth, input.Player1.transform));
                //StartCoroutine(ExampleCoroutine());
                //StartCoroutine(Transition2(input.Player1.transform));
            }
            else {
                StartCoroutine(Transition(nearest, intensidadGlobal, puntoFinal));
                //StartCoroutine(ExampleCoroutine());
                //StartCoroutine(Transition2(puntoFinal));
                //this.GetComponent<Camera>().
            }
         
        }

    }

    IEnumerator Transition(float value, float intensity, Transform ttt)
    {
        float t = 0.0f;
        float ini = this.GetComponent<Camera>().orthographicSize;
        float ints = GameObject.FindGameObjectWithTag("GlobalLigth").GetComponent<Light2D>().intensity;

        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / transitionDuration);
            this.GetComponent<Camera>().orthographicSize = Mathf.Lerp(ini, value, t);
            GameObject.FindGameObjectWithTag("GlobalLigth").GetComponent<Light2D>().intensity = Mathf.Lerp(ints, intensity, t);
            yield return 0;

        }
      
    }
        //float t = 0.0f;
        //float startingPosX = this.transform.position.x;
        //float startingPosY = this.transform.position.y;
        //while (t < 1.0f)
        //{
        //    t += Time.deltaTime * (Time.timeScale / 5);
        //    float x = Mathf.Lerp(startingPosX, tt.position.x, t);
        //    float y = this.transform.position.y;
        //    this.transform.position = new Vector3(x, y, -10);
        //    yield return 0;
        //}

}