using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusBuildingToConstruct : MonoBehaviour
{

    List<Citizen> constructCitizen;
    List<Citizen> carrierCitizen;
    public MeshRenderer mesh;

    public AudioSource sound;

    public Material originalColor;
    //Color originalColor;


    // Use this for initialization
    void Start()
    {
        constructCitizen = GameObject.Find("Dispatcher").GetComponent<DispatcherManager>().constructCitizens;
        carrierCitizen = GameObject.Find("Dispatcher").GetComponent<DispatcherManager>().transportCitizens;
        //originalColor = mesh.material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if(gameObject.tag == "House")
        {
            if (!gameObject.GetComponent<House>().isConstruct && gameObject.GetComponent<House>().isPlaced)
            {
                Building building = gameObject.GetComponent<Building>();
                foreach (Citizen cit in constructCitizen)
                {
                    cit.GetComponent<FSMControler>().manualTarget = gameObject;
                }

                foreach (Citizen cit in carrierCitizen)
                {
                    FSMControler controler = cit.GetComponent<FSMControler>();
                    updateInventory(building, controler);
                    cit.GetComponent<FSMControler>().manualTarget = gameObject;
                }
                StartCoroutine(colorChange());
                musicFeedBack();
            }
        }
        else if(gameObject.tag == "Camp")
        {
            if (!gameObject.GetComponent<Camp>().isConstruct && gameObject.GetComponent<Camp>().isPlaced)
            {
                Building building = gameObject.GetComponent<Building>();
                foreach (Citizen cit in constructCitizen)
                {
                    cit.GetComponent<FSMControler>().manualTarget = gameObject;
                }

                foreach (Citizen cit in carrierCitizen)
                {
                    FSMControler controler = cit.GetComponent<FSMControler>();
                    updateInventory(building, controler);
                    cit.GetComponent<FSMControler>().manualTarget = gameObject;
                }
                StartCoroutine(colorChange());
                musicFeedBack();
            }
        }

        else if (gameObject.tag == "Statue")
        {
            if (!gameObject.GetComponent<Statue>().isConstruct && gameObject.GetComponent<Statue>().isPlaced)
            {
                Building building = gameObject.GetComponent<Building>();

                foreach (Citizen cit in constructCitizen)
                {
                    cit.GetComponent<FSMControler>().manualTarget = gameObject;

                }

                foreach (Citizen cit in carrierCitizen)
                {
                    FSMControler controler = cit.GetComponent<FSMControler>();
                    updateInventory(building, controler);
                    cit.GetComponent<FSMControler>().manualTarget = gameObject;
                }
                StartCoroutine(colorChange());
                musicFeedBack();
            }
        }


    }

    public void updateInventory(Building building,FSMControler controler)
    {
        foreach (RessourceTank rt in controler.citizen.ressourcesToTransport.ressourcesList)
        {

            rt.neededToTransport = false;
            rt.numberToTransport = 0;
        }

        foreach (Tool t in controler.citizen.toolsToTransport.toolInventory)
        {

            t.neededToTransport = false;
            t.nbToTransport = 0;
        }

        if (building.needRessources && building.isPlaced)
        {
            foreach (RessourceTank rt in building.getRessourcesNeeded())
            {

                controler.GetComponent<Citizen>().ressourcesToTransport.add(rt);
            }
            if (building.needTools)
            {
                foreach (Tool t in building.getToolsNeeded())
                {

                    controler.GetComponent<Citizen>().toolsToTransport.add(t);
                }
                return;
            }
            else
            {
                foreach (Tool t in controler.GetComponent<Citizen>().toolsToTransport.toolInventory)
                {
                    t.neededToTransport = false;
                }
            }
        }
        else if (building.needTools && building.isPlaced)
        {
            foreach (Tool t in building.getToolsNeeded())
            {

                controler.GetComponent<Citizen>().toolsToTransport.add(t);
            }
            foreach (RessourceTank rT in controler.GetComponent<Citizen>().ressourcesToTransport.ressourcesList)
            {
                rT.neededToTransport = false;
            }
            return;
        }
    }

    IEnumerator colorChange()
    {
        Debug.Log("change color");
        mesh.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        mesh.material = originalColor;
    }

    public void musicFeedBack()
    {
        sound.Play();
    }
}
