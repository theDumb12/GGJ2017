﻿using UnityEngine;
using System.Collections;

public class ShootyShooty : MonoBehaviour {

    public GameObject[] projectiles;
    public float fireSpeed;
    public float reloadTime;
    public float weaponSwitchCooldown;
    public AudioClip shootSound;
    public int currWeapon = 0;
    //WEAPONS:
    // 0 = Fire
    // 1 = Electricity
    // 2 = Ice
    // 3 = Wind
    public Sprite[] currWeaponSpriteArr;
    //public Animation[] currWeaponAnimArr;
    private PlayerVars vars;

    ///public string swing = "RT";
    public string shoot = "LT";

    private Vector3 joyAim;
    private bool canShoot;
    private bool canSwitch = true;
    private float reload;
    private float switchCooldown;
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

        ///float swingTrig = Input.GetAxis(swing);
        float switchLeft = Input.GetAxis("X");
        float switchRight = Input.GetAxis("B");
        float shootTrig = Input.GetAxis(shoot);
        

        if (switchLeft > 0.0f && canSwitch)
        {
            this.transform.GetChild(0).transform.RotateAround(this.transform.position, new Vector3(0, 0, 1), -90);
            canSwitch = false;
            currWeapon = toLeft(currWeapon);
        }
        else if(switchRight > 0.0f && canSwitch)
        {
            this.transform.GetChild(0).transform.RotateAround(this.transform.position, new Vector3(0, 0, 1), 90);
            canSwitch = false;
            currWeapon = toRight(currWeapon);
        }
        else if(!canSwitch && switchCooldown < weaponSwitchCooldown)
        {
            switchCooldown += Time.deltaTime;
        }
        else if(!canSwitch && (switchCooldown >= weaponSwitchCooldown))
        {
            switchCooldown = 0;
            canSwitch = true;
        }
        if (shootTrig > 0.0f && canShoot)
        {
            //audioSource.PlayOneShot(shootSound);
            joyAim = new Vector3(vars.rStickX, vars.rStickY);

            //Vector3 childPos = this.transform.GetChild(0).transform.localPosition;
            Vector3 vel3D = joyAim.normalized;
            if(vars.rStickX == 0.0f && vars.rStickY == 0.0f)
            {
                vel3D.Set(0.0f,1.0f,0.0f);
            }

            Vector3 fireOffset = vel3D;
            fireOffset.x *= -1.2f;

            GameObject bullet = (GameObject)Instantiate(projectiles[currWeapon],
                                                        transform.position + fireOffset,
                                                        Quaternion.identity);
            setSprite(bullet);
            Physics2D.IgnoreCollision(bullet.gameObject.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
            vel3D *= fireSpeed;
            bullet.GetComponent<ProjectileScript>().vel = new Vector2(-vel3D.x, vel3D.y);
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

    int toLeft(int currWeapon)
    {
        if(currWeapon == 0)
        {
            return 3;
        }
        else
            return currWeapon - 1;
    }
    int toRight(int currWeapon)
    {
        if (currWeapon == 3)
        {
            return 0;
        }
        else
            return currWeapon + 1;
    }

    void setSprite(GameObject bullet)
    {
        //WEAPONS:
        // 0 = Fire
        // 1 = Electricity
        // 2 = Ice
        // 3 = Wind
        //bullet.GetComponent<SpriteRenderer>().sprite = currWeaponSpriteArr[currWeapon];
        //bullet.GetComponent<Animation>() = currWeaponAnimArr[currWeapon];
    }
}
