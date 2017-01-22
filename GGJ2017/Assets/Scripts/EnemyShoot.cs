using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

	public GameObject projectile;
	public float fireSpeed;
	public AudioClip shootSound;
	public Transform target;
	private bool canShoot;
	public float reloadTime;
	private float reload;
	private AudioSource audioSource;
	public string shoot = "LT";

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		float shootTrig = Input.GetAxis(shoot);
		Vector3 vel3D = target.transform.position.normalized;

		if (shootTrig > 0.0f && canShoot)
		{
			audioSource.PlayOneShot(shootSound);

			//Vector3 childPos = this.transform.GetChild(0).transform.localPosition;
			Vector3 fireOffset = vel3D;
			GameObject bullet = (GameObject)Instantiate(projectile,
				transform.position + fireOffset,
				Quaternion.identity);
			Physics2D.IgnoreCollision(bullet.gameObject.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
			vel3D *= fireSpeed;
			bullet.GetComponent<ProjectileScript> ().vel = target.transform.position;
			canShoot = false;
		}
		if (!canShoot && reload < reloadTime)
		{
			reload += Time.deltaTime;
		}
		if (!canShoot && (reload >= reloadTime/* || vars.shootTrig < 0.3)*/))
		{
			canShoot = true;
			reload = 0;
		}
	}

}
