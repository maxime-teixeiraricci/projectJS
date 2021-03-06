﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statue : Building
{
    bool fait = false;

    public Text objStatue;

    public void Start()
    {
        askSupplyToConstruct();
        objStatue = GameObject.Find("CurrentObjectif").GetComponent<Text>();
        //Color colorStart = gameObject.GetComponent<MeshRenderer>().material.color;
        //alphaColor = new Color(colorStart.r, colorStart.g, colorStart.b, 0);
        //GetComponent<MeshRenderer>().material.color = alphaColor;
        toolText = GameObject.FindGameObjectWithTag("ToolText").GetComponent<Text>();
    }

    public void Update()
    {
        base.Update();
        toolText = GameObject.FindGameObjectWithTag("ToolText").GetComponent<Text>();
        //progressionBuild.transform.rotation = Quaternion.LookRotation(progressionBuild.transform.position - Camera.main.transform.position);
        progressionBuild.transform.rotation = Camera.main.transform.rotation;
        if (progressionBuild.text == "100%")
        {
            progressionBuild.text = "";
            foreach(AudioSource audio in GetComponents<AudioSource>())
            {
                if(audio.clip.name == "waou")
                {
                    audio.Play();
                }
            }
        }
        if (!fait)
        {
            askSupplyToConstruct();
            //Color colorStart = gameObject.GetComponent<MeshRenderer>().material.color;
            //alphaColor = new Color(colorStart.r, colorStart.g, colorStart.b, 0);
            //GetComponent<MeshRenderer>().material.color = alphaColor;
            fait = true;
        }

        if (!isConstruct)
        {
            if (!enoughToolsToBuild)
            {
                askSupplyToConstruct();
            }
            else if (!enoughToolsToBuild)
            {
                askSupplyToConstruct();
            }
            else
            {

                if (timeToBuild <= passedTimedBuild)
                {
                    isConstruct = true;
                    objStatue.text = (int.Parse(objStatue.text) + 1).ToString();
                    foreach (RessourceTank r in inventory.getRessourcesNeededConstruct())
                    {
                        for (int i = 0; i < r.numberToConstruct; i++)
                        {
                            inventory.remove(r.ressource);
                            totalNbr.Remove(r.ressource);
                        }

                    }

                    foreach (Tool t in toolsInventory.getToolsNeededConstruct())
                    {
                        for (int i = 0; i < t.nbToConstruct; i++)
                        {
                            toolsInventory.remove(t);
                            toolText.text = (int.Parse(toolText.text) - 1).ToString();
                        }

                    }
                }
            }
        }
    }
    
    public void consommer()
    {
        //On consomme une ressource par habitant et par jour (à définir)
        //Si il n'y a plus de nourriture pour tenir le jour suivant, on appel askSupply
    }

    /*public void createCitizen()
    {
        for (int i = 0; i < 2; i++)
        {
            citizen = Instantiate(citizen, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity) as GameObject;
            citizen.SetActive(true);
            DispatcherManager dm = GameObject.Find("Dispatcher").GetComponent<DispatcherManager>();
            dm.noneCitizens.Add(citizen.GetComponent<Citizen>());
            dm.updateCitizenList(citizen.GetComponent<Citizen>());
        }

    }*/
}
