using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispatcherManager : MonoBehaviour
{
    public static DispatcherManager instance;

    public int product;
    public int collect;
    public int construct;
    public int transport;

    public List<Citizen> productCitizens;
    public List<Citizen> collectCitizens;
    public List<Citizen> constructCitizens;
    public List<Citizen> transportCitizens;
    public List<Citizen> noneCitizens;

    public List<Citizen> gatherersJobless;
    public Citizen[] citizens;

    private void Awake()
    {
        if (!instance) instance = this;
    }


    // Use this for initialization
    void Start ()
    {
        
        citizens = FindObjectsOfType<Citizen>();
        foreach (Citizen c in citizens)
        {
            noneCitizens.Add(c);
        }
        WorldManager.citizenNumber = citizens.Length;

    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateCitizen();
        UpdateWorkPlace();
    }

    void UpdateWorkPlace()
    {
        Camp[] workPlaces = FindObjectsOfType<Camp>(); // A modifier et rendre générique
        //print(workPlaces.Length);
        foreach (Camp workPlace in workPlaces)
        {
            if (! (workPlace.listWorkers.Count == workPlace.numberWorkers) && gatherersJobless.Count > 0 && workPlace.isConstruct)
            {
                workPlace.HireWorker(gatherersJobless[0]);
                gatherersJobless.RemoveAt(0);
            }
        }
    }


    void UpdateCitizen()
    {
        product = Mathf.Max(0, Mathf.Min(citizens.Length, WorldManager.producers));
        collect = Mathf.Max(0, Mathf.Min(citizens.Length, WorldManager.gatherers));
        construct = Mathf.Max(0, Mathf.Min(citizens.Length, WorldManager.constructors));
        transport = Mathf.Max(0, Mathf.Min(citizens.Length, WorldManager.transporters));

        productCitizens = UpdateList(productCitizens, product);
        collectCitizens = UpdateList(collectCitizens, collect);
        constructCitizens = UpdateList(constructCitizens, construct);
        transportCitizens = UpdateList(transportCitizens, transport);

        foreach (Citizen c in productCitizens) c.ChangeGroup(Citizen.Group.Product);
        foreach (Citizen c in collectCitizens) c.ChangeGroup(Citizen.Group.Collect);
        foreach (Citizen c in constructCitizens) c.ChangeGroup(Citizen.Group.Construct);
        foreach (Citizen c in transportCitizens) c.ChangeGroup(Citizen.Group.Transport);
        foreach (Citizen c in noneCitizens) c.ChangeGroup(Citizen.Group.None);
    }

    List<Citizen> UpdateList(List<Citizen> citizens, int number)
    {
        

        if (citizens.Count > number)
        {
            while (citizens.Count > number)
            {
                noneCitizens.Add(citizens[citizens.Count - 1]);
                citizens.RemoveAt(citizens.Count - 1);
            }
        }
        else if (citizens.Count < number)
        {
            while (citizens.Count < number && noneCitizens.Count > 0)
            {
                citizens.Add(noneCitizens[noneCitizens.Count-1]);
                noneCitizens.RemoveAt(noneCitizens.Count - 1);
            }
        }
        return citizens;
    }
}
