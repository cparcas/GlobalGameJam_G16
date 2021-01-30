using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MovementManager : MonoBehaviour
{
    [SerializeField] private float m_MaxSpeed = 10f;         // The fastest the player can travel in the x axis.
    [SerializeField] private float m_JumpForce = 400f;       // Amount of force added when the player jumps.
    [SerializeField] private Transform m_SpawnPoint = null;

    private Animator m_Anim;            // Reference to the player's Animator component.
    private Rigidbody2D m_Rigidbody2D;  // Reference to the player's Rigidbody2D component.
    private BoxCollider2D m_BoxCollider2D;  // Reference to the player's BoxCollider2D component.

    private bool m_Grounded = true;     // Whether or not the player is grounded

   

    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private bool m_HasJumped = false;   // For determining which way the player is currently facing.
    private int m_NumRings = 0;         // Number of rings collected
    private Transform newSpawnPoint;

    public float timeLeft = 0;
    // private AudioSource m_JumpAudio;
    // private AudioSource m_LandAudio;
    // private AudioSource m_StepAudio;
    // private AudioSource m_SpikesAudio;
    // private AudioSource m_CollectRingAudio;

    private void Awake()
    {
        // Setting up references.
        m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_BoxCollider2D = GetComponent<BoxCollider2D>();

        //AudioSource[] audioSources = GetComponents<AudioSource>();
        // m_JumpAudio = audioSources[0];
        // m_LandAudio = audioSources[1];
        // m_StepAudio = audioSources[2];
        // m_SpikesAudio = audioSources[3];
        // m_CollectRingAudio = audioSources[4];
    }
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            this.gameObject.GetComponentInChildren<Light2D>().pointLightOuterRadius = 4;
            this.gameObject.GetComponentInChildren<Light2D>().pointLightInnerRadius = 0.01f;
        }
    }
    private void FixedUpdate()
    {
        //m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);

        if (m_Rigidbody2D.velocity.x != 0 && m_Grounded)
        { 
            //if ( !m_StepAudio.isPlaying)
            //{
            //    m_StepAudio.Play();
            //}

        }else if (m_Rigidbody2D.velocity.x == 0  || !m_Grounded)
        {
            //if (m_StepAudio.isPlaying)
            //{
            //    m_StepAudio.Stop();
            //}
        }
        // Debug.Log(gameObject.name + ": " + m_Grounded + ", " + m_Rolling + ", " + m_HasJumped);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.contacts[0].normal.y > 0) 
        {
            // Debug.Log(gameObject.name + " Enter Collision");
            m_Grounded = true;
            //m_Anim.SetBool("Ground", true);
            //m_LandAudio.Play();

            if (m_HasJumped)
            {
                m_HasJumped = false;
            }
        }
        else
        if (other.collider.CompareTag("Timer"))
        {
            GameObject tt = GameObject.Find("Timer");
            Timer temp = tt.GetComponent<Timer>();
            temp.moreTime();
            Destroy(other.gameObject);
        }else 
        if (other.collider.CompareTag("LigthObj"))
        {
            this.gameObject.GetComponentInChildren<Light2D>().pointLightOuterRadius =10;
            this.gameObject.GetComponentInChildren<Light2D>().pointLightInnerRadius = 0.05f;
            timeLeft = 5;
            Destroy(other.gameObject);
        }


        //else 
        //if (other.collider.CompareTag("Spikes"))
        //{
        //    //m_SpikesAudio.Play();

        //    Respawn();
        //}
        //else if (other.collider.CompareTag("Ring"))
        //{
        //    m_NumRings++;
        //    Destroy(other.gameObject);

        //    //m_CollectRingAudio.Play();
        //}

        //if (other.gameObject.CompareTag("LevelFinish"))
        //{
        //    other.gameObject.GetComponent<SceneCaller>().NextScene();
        //}
    }

    public void Move(float move)
    {
        // Only control the player if grounded or airControl is turned on

        // The Speed animator parameter is set to the absolute value of the horizontal input.
        m_Anim.SetFloat("Speed", Mathf.Abs(move));
        m_Rigidbody2D.freezeRotation = true;

        m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);
        
        // Move the character
       

        // If the input is moving the player one way and the player is facing the other...
        if ((move > 0 && !m_FacingRight) || (move < 0 && m_FacingRight))
        {
            // ... flip the player.
            Flip();
        }
    }

    public void Jump(bool increaseForce)
    {
        // If the player should jump or bounce...
        if (m_Grounded)
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            //m_Anim.SetBool("Ground", false);
            m_HasJumped = true;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Respawn()
    {
        gameObject.transform.position = m_SpawnPoint.position;
    }

    public void ChangeSpawnPoint(Transform transform)
    {
        m_SpawnPoint = newSpawnPoint;
    }

    public bool IsGrounded()
    {
        return m_Grounded;
    }
    internal void removeVelocity()
    {
        m_Rigidbody2D.velocity = new Vector2(0,0);
    }
}
