using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactorsManager : MonoBehaviour {

    public Slider slider;
    float res;

    float value;
    public int nbrTrees;

    float maxRessources;


    private void Start()
    {
        maxRessources = nbrTrees * 500;
    }

    // Update is called once per frame
    void Update ()
    {
        res = environmentShape();
        slider.value = res / maxRessources * 100;
	}

    public float environmentShape()
    {
        res = 0;
        GameObject[] trees = GameObject.FindGameObjectsWithTag("RessourceTank");
        foreach(GameObject tree in trees)
        {
            value = tree.GetComponent<NaturalRessource>().numberRessource;
            res += value;
        }

        return res;
    }
}
