using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour {

    //List of ressources needed to create the building
    [SerializeField]
    public Dictionary<Ressource, int> ressourcesNeeded;
    //isConstruct
    public bool isConstruct = false;
    //number of constructCall needed to be done
    public bool enoughConstructToBuild = false;

    //building inventory
    public Dictionary<Ressource, List<GameObject>> stock = new Dictionary<Ressource, List<GameObject>>(); //le arrayList prend pas la spé d'élément ArrayList<Ressource> pas possible...
    //List of ressources needed to make the building work
    public Dictionary<Ressource, int> ressourcesNeededToWork;

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
