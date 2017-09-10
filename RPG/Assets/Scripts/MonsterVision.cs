using UnityEngine;
using System.Collections;

public class MonsterVision : MonoBehaviour {

    private bool isPlayer = false;
    private float moveSpeed = 3f, diagSpeed = 2.178f; // monster speed
    public float moveCooldown, movingTime;  // monster random movement
    public bool isMoving = false;
    private Vector2 dir;
    private Transform player;
    private Rigidbody2D myRigidbody;
    public bool isTrapped = false;
    private float trappedTime = 0;

	// Use this for initialization
	void Start ()
    {
        myRigidbody = gameObject.GetComponentInParent<Rigidbody2D>();
        moveCooldown = Random.Range(1f, 2f);
        movingTime = Random.Range(1f, 2f);
	}

    // Update is called once per frame
    void Update()
    {
        if (isTrapped == false)
        {
            if (isPlayer) // if there is an enemy in range
            {
                isMoving = true;

                dir = new Vector2(player.position.x, player.position.y);
                dir.x = dir.x - transform.position.x;
                dir.y = dir.y - transform.position.y;

                // fix direction of the monster between -1 and 1
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
                myRigidbody.velocity = dir * moveSpeed;
                if (moveCooldown <= 1f)
                {
                    moveCooldown = Random.Range(1f, 2f);
                }
            }
            else if (movingTime <= 0f)
            {
                Stop();
                movingTime = Random.Range(1f, 2f);
            }

            else if (moveCooldown <= 0f) // choose random movement
            {
                RandomMove();
                moveCooldown = Random.Range(1f, 2f);
            }

            else if (isMoving) // decrease movingTime
            {
                movingTime -= Time.deltaTime;
            }

            else // decrease stop time
            {
                Stop();
                moveCooldown -= Time.deltaTime;
            }

            // fix diagonal speed
            if (myRigidbody.velocity.magnitude > moveSpeed + 0.1f)
            {
                myRigidbody.velocity = dir * diagSpeed;
            }
        }
        else
        {
            Stop();
            trappedTime -= Time.deltaTime;
            if (trappedTime <= 0)
                isTrapped = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        PlayerControlerScript PlayerScript = col.GetComponent<PlayerControlerScript>();
        if (PlayerScript != null)
        {
            isPlayer = true;
            player = col.GetComponent<Transform>();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        PlayerControlerScript PlayerScript = col.GetComponent<PlayerControlerScript>();
        if (PlayerScript != null)
        {
            isPlayer = false;
            Stop();
        }
    }

    private void RandomMove()
    {
        dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        // fix direction of the monster between -1 and 1
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
        myRigidbody.velocity = dir * moveSpeed;
        isMoving = true;
    }

    public void setTrap(float power)
    {
        isTrapped = true;
        trappedTime = power;
    }

    private void Stop()
    {
        myRigidbody.velocity = new Vector2(0, 0);
        isMoving = false;
    }
}
