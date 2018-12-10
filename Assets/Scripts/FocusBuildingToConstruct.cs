using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusBuildingToConstruct : MonoBehaviour
{

    List<Citizen> constructCitizen;
    List<Citizen> carrierCitizen;
    public MeshRenderer mesh;

    Color originalColor;


    // Use this for initialization
    void Start()
    {
        constructCitizen = GameObject.Find("Dispatcher").GetComponent<DispatcherManager>().constructCitizens;
        carrierCitizen = GameObject.Find("Dispatcher").GetComponent<DispatcherManager>().transportCitizens;
        originalColor = mesh.material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if(gameObject.tag == "House")
        {
            if (!gameObject.GetComponent<House>().isConstruct)
            {
                foreach (Citizen cit in constructCitizen)
                {
                    cit.GetComponent<FSMControler>().manualTarget = gameObject;
                }

                foreach (Citizen cit in carrierCitizen)
                {
                    cit.GetComponent<FSMControler>().manualTarget = gameObject;
                }
                StartCoroutine(colorChange());
            }
        }
        else if(gameObject.tag == "Camp")
        {
            if (!gameObject.GetComponent<Camp>().isConstruct)
            {
                foreach (Citizen cit in constructCitizen)
                {
                    cit.GetComponent<FSMControler>().manualTarget = gameObject;
                }

                foreach (Citizen cit in carrierCitizen)
                {
                    cit.GetComponent<FSMControler>().manualTarget = gameObject;
                }
                StartCoroutine(colorChange());
            }
        }
        

        

    }

    IEnumerator colorChange()
    {
        mesh.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        mesh.material.color = originalColor;
    }
}
