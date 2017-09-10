using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    private GameObject player;
    public Vector2 dir;
    private float speed = 6f;
    private int damage = 1;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5f);
        player = GameObject.Find("Player");

        // fix direction of the bullet between -1 and 1
        if (Mathf.Abs(dir.x) >= Mathf.Abs(dir.y))
        {
            dir.y = dir.y / Mathf.Abs(dir.x);
            dir.x = dir.x / Mathf.Abs(dir.x);
        }
        else
        {
            dir.x = dir.x / Mathf.Abs(dir.y);
            dir.y = dir.y / Mathf.Abs(dir.y);
        }
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody2D>().velocity = dir * speed;

	}

    public int GetDamage()
    {
        return damage;
    }
}
