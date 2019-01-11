using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrees : MonoBehaviour {

    public AudioSource fallingTree;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        checkTrees();
	}

    public void checkTrees()
    {
        GameObject[] trees = GameObject.FindGameObjectsWithTag("RessourceTank");
        foreach (GameObject tree in trees)
        {
            if (tree.GetComponent<NaturalRessource>().numberRessource <= 0)
            {
                fallingTree.Play();
                Destroy(tree);
            }
        }
    }
}
