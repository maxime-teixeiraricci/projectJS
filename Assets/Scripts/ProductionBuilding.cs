using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionBuilding : Building {

    List<Recipe> recipes;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public override void addRessource(Ressource ressource, int quantite)
    {
        throw new System.NotImplementedException();
    }

    void product(Recipe recipe)
    {

    }

    void askSupply()
    {

    }

    void give(Ressource ressource)
    {

    }
}
