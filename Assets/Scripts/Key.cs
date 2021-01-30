using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    [SerializeField] private Color color;
    private GameObject player;
    public AudioSource key_audio;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
           
            GameObject key =  this.gameObject;
            MovementManager movementManagerScript = player.GetComponent<MovementManager>();
            movementManagerScript.actualKey = key;
            key_audio.Play();
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
        }

    }



}
