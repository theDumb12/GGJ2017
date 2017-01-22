using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMove : MonoBehaviour {

	public float speed = 0.3f;
	private Rigidbody2D rb;
	private Animator animator;
	private bool isHit = false;
    /* defines field of movement within the camera
     * index 0 = left bound
     * index 1 = right bound
     * index 2 = bottom bound
     * index 3 = upper bound
     */
    private float[] moveField = new float[4];

	// Use this for initialization
	void Start () {
		
		rb = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator>();

		isHit = false;

		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;

        //define field of movement within camera
		moveField[Constants.XMIN] = Camera.main.ViewportToWorldPoint(new Vector3(0,0, distanceToCamera)).x;
		moveField[Constants.XMAX] = Camera.main.ViewportToWorldPoint(new Vector3(1,0, distanceToCamera)).x;
		moveField[Constants.YMAX] = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distanceToCamera)).y;
		moveField[Constants.YMIN] = Camera.main.ViewportToWorldPoint(new Vector3(0,1,distanceToCamera)).y;
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 location = transform.position;

        if (location.x > moveField[Constants.XMAX]-5 || location.x < moveField[Constants.XMIN]+5)
            speed = -speed;

        location.x += speed;
        transform.position = location;

        if (isHit)
            Destroy(gameObject);
    }

	public void TakeHit(){
		if (!isHit){
				isHit = true;
		}
	}
    private class Constants
    {
        public const int XMIN = 0;
        public const int XMAX = 1;
        public const int YMAX = 2;
        public const int YMIN = 3;
    }
}
