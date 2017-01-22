using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

    public float force;
    public Vector2 vel;
    public float speed;
    public float damage = 1;
    public float maxLifetime;
    public bool doesDamage;

    private float lifetime;
    private Rigidbody2D rb;
    //private float rStickY;
    //private float rStickX;


    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = vel * speed;
        Vector3 dir = rb.velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);

        lifetime = 0;
    }

	// Update is called once per frame
	void FixedUpdate () {
        lifetime += Time.deltaTime;
        if (lifetime >= maxLifetime)
        {
            GameObject.Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //audioSouce.PlayOneShot(explosionSound);

        //Debug.Log("COLLISION ENTER FOR PROJECTILE");
        if (coll.gameObject.tag == "Player")
        {
           //coll.gameObject.GetComponent<WerewolfMovement>().TakeDamage(damage);
           //coll.gameObject.GetComponent<WerewolfMovement>().damaged = true;
           //coll.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

            // Hit the player
            //coll.gameObject.GetComponent<WerewolfMovement>().hit(-coll.contacts[0].normal, force, damage);
        }
		if (coll.gameObject.tag == "Enemy" && doesDamage) {
			coll.gameObject.GetComponent<BasicEnemyMove>().TakeHit();
		}
        if(doesDamage)
        {
            Destroy(gameObject);
        }
    }
}
