using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public float defaultvalue;

    public bool globalCamera;


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
            //Debug.Log("Estoy entrando aqui bro");
            this.transform.position = new Vector3(input.Player1.transform.position.x, input.Player1.transform.position.y, this.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.E) && timer.canChange)
        {
            timer.inciarContador = !timer.inciarContador;
            input.canMove = !input.canMove;
            globalCamera = !globalCamera;
            if (globalCamera)
            {
                StartCoroutine(Transition(input.Player1.transform, defaultvalue));
            }
            else {
                StartCoroutine(Transition(target, nearest));
            }
         
        }

    }

    IEnumerator Transition(Transform tt, float value)
    {
        float t = 0.0f;
        float startingPosX = this.transform.position.x;
        float startingPosY = this.transform.position.y;
        float ini = this.GetComponent<Camera>().orthographicSize;
        while (t < 1.0f)
        {
            //Debug.LogWarning("VALGO" + this.GetComponent<Camera>().orthographicSize);
            this.GetComponent<Camera>().orthographicSize = Mathf.Lerp(ini, value, t);
            t += Time.deltaTime * (Time.timeScale / transitionDuration);
            float x= Mathf.Lerp(startingPosX, tt.position.x, t);
            float y = Mathf.Lerp(startingPosY, tt.position.y, t);

            this.transform.position= new Vector3(x, y, -10);

          
            yield return 0;
        }

    }
}