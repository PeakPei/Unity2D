using UnityEngine;
using System.Collections;

public class CameraControler : MonoBehaviour {

    private GameObject followTarget;
    private Vector3 targetPos;
    private float moveSpeed = 5f;

	// Use this for initialization
	void Start () {
        followTarget = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
	}
}
