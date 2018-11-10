using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour {

    Dictionary<Ressource, int> ressourcesNeeded;
    Dictionary<Ressource, List<Ressource>> stock; //le arrayList prend pas la spé d'élément ArrayList<Ressource> pas possible...

    int niveau;
    List<Citizen> citizens;

    abstract public void addRessource(Ressource ressource, int quantite);
}
