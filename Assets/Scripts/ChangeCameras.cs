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
        Vector3 startingPos = this.transform.position;
        while (transform.position != tt.position)
        {
            t += Time.deltaTime * (Time.timeScale / transitionDuration);
            transform.position = Vector3.Lerp(startingPos, tt.position, t);
            this.GetComponent<Camera>().orthographicSize = Mathf.Lerp(this.GetComponent<Camera>().orthographicSize, value, t);
            yield return 0;
        }

    }
}