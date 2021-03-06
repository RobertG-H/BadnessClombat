﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public float Speed;
    public float RotationSpeed;
    public GameObject[] MyWaypoints; // to define the movement waypoints
    private Rigidbody2D rb;

    private Vector3[] ANGLES = new Vector3[] { new Vector3(0,0,90), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 180) };

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void move(int from, int to)
    {
        //Debug.Log("Sdas");
        if(transform.position == MyWaypoints[to].transform.position)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            transform.position = Vector2.MoveTowards(rb.position, MyWaypoints[to].transform.position, Speed * Time.deltaTime);
            transform.eulerAngles = Vector3.RotateTowards(transform.eulerAngles, ANGLES[to],0.0f, RotationSpeed);
        }
    }
}
