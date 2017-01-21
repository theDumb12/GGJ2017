﻿using UnityEngine;
using System.Collections;

public class ShootyShooty : MonoBehaviour {

    public GameObject projectile;
    public float fireSpeed;
    public float reloadTime;
    public AudioClip shootSound;
    private PlayerVars vars;

    public string swing = "RT";
    public string shoot = "LT";

    private Vector3 joyAim;
    private bool canShoot;
    private float reload;
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        vars = gameObject.GetComponent<PlayerVars>();
        audioSource = gameObject.GetComponent<AudioSource>();

        joyAim = new Vector3(1.0f, 0.0f, 0);
        canShoot = true;
        reload = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {

       // Vector3 mousePt = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float swingTrig = Input.GetAxis(swing);
        float shootTrig = Input.GetAxis(shoot);

        if (shootTrig > 0.0f && canShoot)
        {
            audioSource.PlayOneShot(shootSound);
            joyAim = new Vector3(vars.rStickX, vars.rStickY);

            //Vector3 childPos = this.transform.GetChild(0).transform.localPosition;
            Vector3 vel3D = joyAim.normalized;
            if(vars.rStickX == 0.0f && vars.rStickY == 0.0f)
            {
                vel3D.Set(0.0f,1.0f,0.0f);
            }

            GameObject bullet = (GameObject)Instantiate(projectile,
                                                        transform.position,
                                                        Quaternion.identity);
            Physics2D.IgnoreCollision(bullet.gameObject.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
            vel3D *= fireSpeed;
            bullet.GetComponent<ProjectileScript>().vel = new Vector2(vel3D.x, -vel3D.y);
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