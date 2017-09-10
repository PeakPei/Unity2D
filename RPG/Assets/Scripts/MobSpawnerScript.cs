using UnityEngine;
using System.Collections;

public class MobSpawnerScript : MonoBehaviour {

    public GameObject poringPrefab;
    private int numberOfPoring, poringMax = 5;

	// Use this for initialization
	void Start () {
        InvokeRepeating("CreateMonster", 0f, 5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void CreateMonster()
    {
        // count nb of mob, if < then spawn
        numberOfPoring = GameObject.FindGameObjectsWithTag("Poring").Length;
        if (numberOfPoring < poringMax)
        {
            GameObject mobClone = Instantiate(poringPrefab, transform.position, transform.rotation) as GameObject;
        }
    }
}
