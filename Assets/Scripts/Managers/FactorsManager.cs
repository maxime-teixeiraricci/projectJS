using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactorsManager : MonoBehaviour {

    public Slider slider;
    float res;

    float value;
    int nbrTrees;

    public GameObject sliderColor;

    float maxRessources;
    Color color;


    private void Start()
    {
        nbrTrees = GameObject.FindGameObjectsWithTag("RessourceTank").Length;
        maxRessources = nbrTrees * GameObject.FindGameObjectWithTag("RessourceTank").GetComponent<NaturalRessource>().maxRessource;
    }

    // Update is called once per frame
    void Update ()
    {
        res = environmentShape();
        slider.value = res / maxRessources * 100;
        updateColor();  
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

    public void updateColor()
    {
        if (slider.value < 60 && slider.value > 30)
        {
            sliderColor.GetComponent<Image>().color = Color.yellow;
        }

        else if (slider.value < 30)
        {
            sliderColor.GetComponent<Image>().color = Color.red;
        }

        else
        {
            sliderColor.GetComponent<Image>().color = Color.green;
        }
    }
}
