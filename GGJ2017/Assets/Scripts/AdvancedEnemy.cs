using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedEnemy : MonoBehaviour {

	public float speed = 0.5f;
	private Rigidbody2D rb;
	private Animator animator;
	private bool isHit;
	public Transform target;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator>();

		isHit = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeHit(){
		if (!isHit) {
			isHit = true;
		}
	}
}
