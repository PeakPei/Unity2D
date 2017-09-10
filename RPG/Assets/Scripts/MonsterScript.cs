using UnityEngine;
using System.Collections;

public class MonsterScript : MonoBehaviour {

    private float moveSpeed = 2f;
    private Vector2 dir = new Vector2 (0, 0);
    private int hp = 2;
    private Rigidbody2D myRigidbody;
    public GameObject xpPrefab;
    private int xp = 5;

	// Use this for initialization
	void Start () {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    // when hit by a bullet
    void OnTriggerEnter2D (Collider2D col)
    {
        BulletScript bullet = col.GetComponent<BulletScript>();
        if (bullet != null)
        {
            GetsHit(bullet.GetDamage());
            Destroy(col.gameObject);
        }
    }

    // hits the monster and kills him if no hp left
    private void GetsHit(int damage)
    {
        hp = hp - damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    // kills the monster
    private void Die()
    {
        DropExp(xp);
        Destroy(gameObject);
    }

    // drop exp
    private void DropExp(int xp)
    {
        GameObject xpClone = Instantiate(xpPrefab, transform.position, transform.rotation) as GameObject;
    }
}
