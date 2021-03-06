﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    /* Enemy Variables needed:
     * -Color
     * -Movement Type
     */
    public float speed = 0.3f;
    public int color = Constants.ICE;
    Vector3 origin;
    public delegate void EnemyMove(float xpos, float ypos, int speed);

    private Rigidbody2D rb;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 location = transform.position;
        Move(ref location.x, ref location.y);
        transform.position = location;
	}

    //Moves the enemy
    private void Move(ref float xpos, ref float ypos)
    {
        if (xpos - origin.x < -10.0f || xpos - origin.x > 10.0f)
            speed = -speed;

        xpos += speed;
    }

    private class Constants {
        //Constants for the different elements
        public const int FIRE = 0;
        public const int ICE = 1;
        public const int WIND = 2;
        public const int LIGHTNING = 3;

        //Constants for movement
        public const int SPEED = 1;
    }
}
