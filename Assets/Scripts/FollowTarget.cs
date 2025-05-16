using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public float scrollSpeed = 8;

    private GameObject player;
    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tag.PLAYER);
        offset = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // camera follow player
        transform.position = player.transform.position - offset;

    }
}