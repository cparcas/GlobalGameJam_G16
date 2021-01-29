using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        MovementManager player = GetComponent<MovementManager>();
        player.ChangeSpawnPoint(transform);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
