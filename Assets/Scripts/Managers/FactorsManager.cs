using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactorsManager : MonoBehaviour {

    public static FactorsManager singleton;

    public Slider slider;
    float res;

    public float value;
    int nbrTrees;

    public GameObject sliderColor;
    public RessourceTank wood;

    float maxRessources;
    Color color;

    public FMODUnity.StudioEventEmitter mainTheme;

    private void Start()
    {
        if (!singleton) singleton = this;
        else Destroy(this);
        nbrTrees = GameObject.FindGameObjectsWithTag("RessourceTank").Length;
        maxRessources = nbrTrees * GameObject.FindGameObjectWithTag("RessourceTank").GetComponent<NaturalRessource>().maxRessource;
    }

    // Update is called once per frame
    void Update ()
    {
        res = environmentShape();
        slider.value = Mathf.Min(1f,res / maxRessources ) * 100;
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
            FMOD.Studio.ParameterInstance parameter;
            mainTheme.EventInstance.getParameter("Etat", out parameter);
            if (!parameter.Equals(null))
            {
                parameter.setValue(0.6f);
            }
        }

        else if (slider.value < 30)
        {
            sliderColor.GetComponent<Image>().color = Color.red;
            FMOD.Studio.ParameterInstance parameter;
            mainTheme.EventInstance.getParameter("Etat", out parameter);
            if (!parameter.Equals(null))
            {
                parameter.setValue(0.3f);
            }
        }

        else
        {
            sliderColor.GetComponent<Image>().color = Color.green;
            FMOD.Studio.ParameterInstance parameter;
            mainTheme.EventInstance.getParameter("Etat", out parameter);
            if (!parameter.Equals(null))
            {
                parameter.setValue(1.6f);
            }
        }
    }
    

    public void AddRessource(float value)
    {
        GameObject[] trees = GameObject.FindGameObjectsWithTag("RessourceTank");
        foreach (GameObject tree in trees)
        {
            tree.GetComponent<NaturalRessource>().numberRessource += value ;

        }
        if (value < 0)
        {
            value = -value;
            for (int i = 0; i < value * trees.Length; i++)
            {
                FindObjectOfType<Camp>().inventory.ressourcesList[0].number++;
                ResourcesCount.singleton.Add(FindObjectOfType<Camp>().inventory.ressourcesList[0].ressource);
            }
        }
        
    }
}
