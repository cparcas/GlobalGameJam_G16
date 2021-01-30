using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] GameObject keyThatOpensThisMotherfuckingDoor;
    public enum State { CLOSED, OPEN }

    public AudioSource door_audio;

    private State door_state = State.CLOSED; //inicialmente esta cerrada

    private GameObject key;




    public State DoorState
    {
        get { return door_state; }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        GameObject actualKey = key.gameObject.GetComponent<MovementManager>().actualKey;
        if (obj.gameObject.tag == "Player" && keyThatOpensThisMotherfuckingDoor == actualKey)
        {
            BoxCollider2D collider = this.GetComponent<BoxCollider2D>();
            collider.enabled = false;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (DoorState == State.CLOSED)
        {
            door_state = State.OPEN;
            door_audio.Play();

        }
    }
}

