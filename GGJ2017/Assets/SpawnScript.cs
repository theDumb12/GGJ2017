using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public float respawnTimer;
    public GameObject enemyPrefab;

    private float respawnDiff = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(respawnDiff >= respawnTimer)
        {
            GameObject enemy = (GameObject)Instantiate(enemyPrefab,
                                                        transform.position,
                                                        Quaternion.identity);
            respawnDiff = 0.0f;
        }
        else
        {
            respawnDiff += Time.deltaTime;
        }
	}
}
