using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour {

    public Dictionary<Ressource, int> ressourcesNeeded;
    public Dictionary<Ressource, List<GameObject>> stock = new Dictionary<Ressource, List<GameObject>>(); //le arrayList prend pas la spé d'élément ArrayList<Ressource> pas possible...
    public int tools;

    int niveau;
    List<Citizen> citizens;

    abstract public void addRessource(GameObject ressource, int quantite);
}
