using UnityEngine;
using System.Collections;

public class PlayerControlerScript : MonoBehaviour {

    private float moveSpeed = 5f, diagSpeed= 3.535f;
    private Vector2 dir;
    private Animator anim;
    private bool isMoving;
    private Vector2 lastMove;
    private Rigidbody2D myRigidbody;
    private int exp = 0;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        isMoving = false;

        // movement and speed limit
            // movement
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        myRigidbody.velocity = dir * moveSpeed;
            // speed limit on diagonal
       if (myRigidbody.velocity.magnitude > moveSpeed)
        {
            myRigidbody.velocity = dir * diagSpeed;
        }
        //
        // if player is moving
            // on x
        if (dir.x != 0)
        {
            isMoving = true;
            lastMove = new Vector2(dir.x, 0f);
        }
            // on y
        if (dir.y != 0)
        {
            isMoving = true;
            lastMove = new Vector2(0f, dir.y);
        }
        //
        anim.SetBool("isMoving", isMoving);

        // set running animation
        anim.SetFloat("MoveX", dir.x);
        anim.SetFloat("MoveY", dir.y);

        // set idle animation
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }

    public void AddExp(int xp)
    {
        exp += xp;
    }
}
