using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = new Vector3(0, 2, 0);
    }
}
