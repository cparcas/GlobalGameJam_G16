using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] public MovementManager Player1 = null;

    // State variables
    private bool m_Jump1 = false;
    public bool canMove = true;

    private void Update()
    {
        if (Player1.IsGrounded() && canMove)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Jump1 = true;
            }
        }
    }

    private void FixedUpdate()
    {
        // Read the inputs.
        float h = Input.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        if (canMove) { Player1.Move(h); } else { Player1.removeVelocity(); }
    
        if (m_Jump1)
        {
            Player1.Jump(false);
            m_Jump1 = false;
        }
    }

    private void ChangePlayer()
    {
        if (Input.GetKeyDown(KeyCode.E) && canMove) //you are looking for 'Lost' once you press E
        {

            canMove = !canMove;
        }
        else if (Input.GetKeyDown(KeyCode.E) && !canMove) //you can see all with 'Found' pressing E
        {

            canMove = !canMove;
        }
    }
}
