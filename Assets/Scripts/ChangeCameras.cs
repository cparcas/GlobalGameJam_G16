using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameras : MonoBehaviour
{
    [SerializeField]
    Camera cam1 = null;    
    
    [SerializeField]
    Camera cam2 = null;
    [SerializeField]
    InputManager input;

    public void  Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        input.canMove = true;
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
            input.canMove = !input.canMove;
        }
    }
}
