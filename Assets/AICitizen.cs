using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICitizen : MonoBehaviour
{
    public CitizenNavigation citizen;
    public delegate void State();
    public Dictionary<string, State> States = new Dictionary<string, State>();
    public string currentState;
    public Vector3 t;
    public GameObject[] g;

    void Awake()
    {
        States["Recolt"] = delegate ()
        {
            
            
            if (citizen.ressources.Count == 5 || GameObject.FindGameObjectsWithTag("Ressource").Length == 0)
            {
                currentState = "Stock";
                return;
            }
            g = GameObject.FindGameObjectsWithTag("Ressource");
            citizen.agent.destination = GameObject.FindGameObjectWithTag("Ressource").transform.position;
        };

        States["Stock"] = delegate ()
        {
            
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Batiment").Length; i++)
            {
                if (!GameObject.FindGameObjectsWithTag("Batiment")[i].GetComponent<Shelter>().full)
                {
                    citizen.agent.destination = GameObject.FindGameObjectsWithTag("Batiment")[i].transform.position;
                    
                    if (citizen.ressources.Count == 0)
                    {
                        currentState = "Recolt";
                    }
                    return;
                }
            }
            currentState = "Recolt";


        };

        currentState = "Recolt";
    }

    private void Update()
    {
        States[currentState]();
    }


}
