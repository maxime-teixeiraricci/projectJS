using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour {

    //building inventory
    public RessourceInventory stock = new RessourceInventory();
    //List of ressources needed to make the building work (crafter)
    public RessourceInventory ressourcesNeededToWork = new RessourceInventory();

    //List of ressources needed to create the building
    public RessourceInventory ressourcesNeededToConstruct = new RessourceInventory();
    public RessourceInventory ressourcesLimitStock = new RessourceInventory();

    //isConstruct
    public bool isConstruct = false;
    public bool enoughConstructToBuild = false;

    
    
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
}

