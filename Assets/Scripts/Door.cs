using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] GameObject keyThatOpensThisMotherfuckingDoor;
    public enum State { CLOSED, OPEN }

    //public AudioSource door_audio;

    private State door_state = State.CLOSED; //inicialmente esta cerrada

    private GameObject key;
    private GameObject player;
    private bool playerRange = false;



    public State DoorState
    {
        get { return door_state; }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void removeCollider()
    {
        BoxCollider2D[] colliders = this.GetComponents<BoxCollider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = false;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        MovementManager movementManagerScript = player.GetComponent<MovementManager>();
        GameObject actualKey = movementManagerScript.actualKey;
        if (obj.gameObject.tag == "Player" && keyThatOpensThisMotherfuckingDoor == actualKey)
        {
            Debug.Log("ABRIR");
            playerRange = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (DoorState == State.CLOSED)
        {
            if (playerRange)
            {
                door_state = State.OPEN;
                // door_audio.Play();
            }

        }
    }
}

