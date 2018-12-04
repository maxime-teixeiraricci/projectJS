using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour {

    //building inventory
    public RessourceInventory inventory;
    public bool needRessource;
    //isConstruct
    public bool isConstruct = false;
    public bool enoughConstructToBuild = false;
    public bool isPlaced = false;
    public bool goodPosition;
    
    public float buildFrequence = 1.0f;

    public Color alphaColor;
    // Temps qu'il faut pour construire le batiment
    public float timeToBuild = 5.0f;
    //building level
    int niveau;
    //building attached citizens list
    List<Citizen> citizens;
    //Competence builder
    public string nameCompetence;
    abstract public void addRessource(GameObject ressource, int quantite);
    abstract public void construct();
    abstract public void askForConstructer();
    abstract public void askSupplyToConstruct();
    abstract public void give(Ressource ressource, Citizen citizen);
    abstract public void take(Ressource ressource, Citizen citizen);
}

