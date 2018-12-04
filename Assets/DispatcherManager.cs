﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispatcherManager : MonoBehaviour
{
    public int product;
    public int collect;
    public int construct;
    public int transport;

    public List<Citizen> productCitizens;
    public List<Citizen> collectCitizens;
    public List<Citizen> constructCitizens;
    public List<Citizen> transportCitizens;
    public List<Citizen> noneCitizens;


    public Citizen[] citizens;
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