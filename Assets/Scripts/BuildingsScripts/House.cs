using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building {
    bool fait = false;

    public GameObject citizen;

    public void Start()
    {
        askSupplyToConstruct();
        Color colorStart = gameObject.GetComponent<MeshRenderer>().material.color;
        alphaColor = new Color(colorStart.r, colorStart.g, colorStart.b, 0);
        GetComponent<MeshRenderer>().material.color = alphaColor;
    }
	
	public void Update () {
        //progressionBuild.transform.rotation = Quaternion.LookRotation(progressionBuild.transform.position - Camera.main.transform.position);
        progressionBuild.transform.rotation = Camera.main.transform.rotation;
        if (progressionBuild.text == "100%")
        {
            progressionBuild.text = "";
        }
        if (!fait)
        {
            askSupplyToConstruct();
            Color colorStart = gameObject.GetComponent<MeshRenderer>().material.color;
            alphaColor = new Color(colorStart.r, colorStart.g, colorStart.b, 0);
            GetComponent<MeshRenderer>().material.color = alphaColor;
            fait = true;
        }
        
        if (!isConstruct)
        {
            if (!enoughConstructToBuild)
            {
                askSupplyToConstruct();
            }
            else
            {
                askForConstructer();
                if (timeToBuild <= passedTimedBuild)
                {
                    isConstruct = true;
                    createCitizen();
                    foreach (RessourceTank r in inventory.getRessourcesNeededConstruct())
                    {
                        for(int i = 0; i < r.numberToConstruct; i++)
                        {
                            inventory.remove(r.ressource);
                            totalNbr.Remove(r.ressource);
                        }
                        
                    }
                }
            }
        }
    }

    public override void askForConstructer()
    {
        //Lors du placement du batiment il demande a être construit jusqu'à ce qu'il le soit
        //Demande au "camp de constructeurs" ou au dispacher
    }

    public void consommer()
    {
        //On consomme une ressource par habitant et par jour (à définir)
        //Si il n'y a plus de nourriture pour tenir le jour suivant, on appel askSupply
    }

    public void createCitizen()
    {
        for(int i = 0; i < 2; i++)
        {
            citizen = Instantiate(citizen, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity) as GameObject;
            citizen.SetActive(true);
            DispatcherManager dm = GameObject.Find("Dispatcher").GetComponent<DispatcherManager>();
            dm.noneCitizens.Add(citizen.GetComponent<Citizen>());
            dm.updateCitizenList(citizen.GetComponent<Citizen>());
        }
        
    }
}
