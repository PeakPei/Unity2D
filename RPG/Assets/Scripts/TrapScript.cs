using UnityEngine;
using System.Collections;

public class TrapScript : MonoBehaviour {

    float   power = 3;
    float   time = 30.0f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, time);
	}
	
    // when a monster walks on a trap
    void OnTriggerEnter2D(Collider2D col)
    {
        MonsterVision monster = col.GetComponentInChildren<MonsterVision>();
        if (monster)
        {
            monster.setTrap(power);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
