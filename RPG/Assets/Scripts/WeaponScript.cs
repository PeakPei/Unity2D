using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

    private GameObject player;
    public GameObject bulletPrefab;
    private Vector3 dir;
    private bool canShoot = true;
    private float shootTime = 0f, shootCooldown = 1.5f;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

        if (shootTime <= 0f)
        {
            canShoot = true;
        }
        else
        {
            shootTime -= Time.deltaTime;
        }

	    if (Input.GetButtonDown("Fire1")&& canShoot)
        {
            dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dir.x = dir.x - player.transform.position.x;
            dir.y = dir.y - player.transform.position.y;
            GameObject clone = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
            clone.GetComponent<BulletScript>().dir.x = dir.x;
            clone.GetComponent<BulletScript>().dir.y = dir.y;
            shootTime = shootCooldown;
            canShoot = false;
        }
	}
}
