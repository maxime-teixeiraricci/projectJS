using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

    public Ressource appleRessource;
    public Ressource woodRessource;

    public Image appleImage;
    public Image woodImage;

    public Text nbrCitizens;

    public Text nbrWood;

    int res = 0;

    // Use this for initialization
    void Start ()
    {
        appleImage.sprite = appleRessource.image;
        woodImage.sprite = woodRessource.image;
	}
	
	// Update is called once per frame
	void Update ()
    {
        calculateCitizens();
        //calculateWood();

	}

    public void calculateCitizens()
    {
        Citizen[] citizen = FindObjectsOfType<Citizen>();
        nbrCitizens.text = "x  " + citizen.Length.ToString();
    }
    /*
    public void calculateWood()
    {
        res = 0;
        Building[] buildings = FindObjectsOfType<Building>();
        foreach(Building building in buildings)
        {
            foreach(RessourceTank rt in building.GetComponent<RessourceInventory>().ressourcesList)
            {
                res += rt.number;
            }
        }

        nbrWood.text = res.ToString();
    }

    public void minusWood()
    {
        res -= 1;
    } 
    */
}
