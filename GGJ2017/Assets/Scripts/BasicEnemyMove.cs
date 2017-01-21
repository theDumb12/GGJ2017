using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMove : MonoBehaviour {

	public float speed = 1.0f;
	public float width = 10f;
	public float height = 5f;
	public GameObject enemyPrefab;
	public bool moveEnabled = true;
	private Rigidbody2D rb;
	private Animator animator;
	private bool isHit = false;
	private float xmax;
	private float xmin;
	private float ymax;
	private float ymin;
	private bool movingRight = true;
	private bool movingDown = true;

	// Use this for initialization
	void Start () {
		
		rb = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator>();

		isHit = false;

		foreach(Transform child in transform){
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		var leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0,0, distanceToCamera)).x;
		var rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1,0, distanceToCamera)).x;
		var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distanceToCamera)).y;
		var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,1,distanceToCamera)).y;
			
		xmax = rightEdge;
		xmin = leftBoundary;
		ymax = topBorder;
		ymin = bottomBorder;
	}
	
	// Update is called once per frame
	void Update () {
		if(movingRight){
			transform.position += new Vector3(Random.Range(0, 0), 0, 0) * speed * Time.deltaTime;
		}else{
			transform.position += new Vector3(Random.Range(0, 0), 0, 0) * speed * Time.deltaTime;
		}if(movingDown){
			transform.position += new Vector3(0, Random.Range(0, 0), 0) * speed * Time.deltaTime;
		}else{
			transform.position += new Vector3(0, Random.Range(0, 0), 0) * speed * Time.deltaTime;
		}

		// Check if the formation is going outside the playspace...
		float rightEdgeOfFormation = transform.position.x + (0.5f*width);
		float leftEdgeOfFormation = transform.position.x - (0.5f*width);
		float topEdgeOfFormation = transform.position.y + (0.5f*height);
		float bottomEdgeOfFormation = transform.position.y - (0.5f*height);
		if(leftEdgeOfFormation < xmin || rightEdgeOfFormation > xmax){
			movingRight = !movingRight;
		}
		if(bottomEdgeOfFormation < ymin || topEdgeOfFormation > ymax){
			movingDown = !movingDown;
		}

		if (isHit) {
			Destroy (gameObject);
		}
	}

	public void TakeHit(){
		if (!isHit){
				isHit = true;
		}
	}
}
