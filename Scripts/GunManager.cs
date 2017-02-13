using UnityEngine;
using System.Collections;

public class GunManager : MonoBehaviour {

    public bool firing;

    public BulletController bullet;
    public float bulletSpeed;
    public int weaponDamage;

    public float timeBetweenShots;
    float shotCounter;

    public Transform firePoint;

    private WeaponGraphics currentGraphics;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

        shotCounter -= Time.deltaTime;

        if (firing)
        {
            if(shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                newBullet.speed = bulletSpeed;
                newBullet.damage = weaponDamage;
            }
        }	
	}
}
