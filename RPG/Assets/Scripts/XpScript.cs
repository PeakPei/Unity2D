using UnityEngine;
using System.Collections;

public class XpScript : MonoBehaviour {

    private int exp = 1;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        PlayerControlerScript player = col.GetComponent<PlayerControlerScript>();
        if (player != null)
        {
            player.AddExp(exp);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
