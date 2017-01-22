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
        target = GameObject.FindGameObjectWithTag("Player").transform;

        if (Vector3.Distance(transform.position, target.position) >= 5)
        {
            float step = speed * Time.deltaTime * 6.0f;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
        

            
     }

	public void TakeHit(){
		if (!isHit) {
			isHit = true;
		}
	}
}
