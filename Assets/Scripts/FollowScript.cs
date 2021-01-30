﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    // Start is called before the first frame update
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
    }
}
