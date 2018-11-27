using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour {

    public Dictionary<Ressource, int> ressourcesNeeded;
    public Dictionary<Ressource, List<GameObject>> stock = new Dictionary<Ressource, List<GameObject>>(); //le arrayList prend pas la spé d'élément ArrayList<Ressource> pas possible...
    public int tools;

    // Temps qu'il faut pour construire le batiment
    public int timeToBuild = 5;
    // Temps passé à construire le batiment
    public int progressBuild = 0;

    int niveau;
    List<Citizen> citizens;

    abstract public void addRessource(GameObject ressource, int quantite);
}
