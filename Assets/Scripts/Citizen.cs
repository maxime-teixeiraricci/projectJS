using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour {

    enum Groupes { Recolteur, Transporteur, Producteur};
    enum Etats { Sain, Malade, Mort };

    Dictionary<Ressource, int> capacitesInventaire;
    Dictionary<Ressource, int> inventaire;
    Dictionary<string, int> competences;

    float age;

    bool isFull;
    bool canWork;

    int soifMax;
    int faimMax;
    int vieMax;

    int soifCourante;
    int faimCourante;
    int vieCourante;

    void Start () {
		
	}
	
	void Update () {
		
	}

    void consommer(Ressource ressource)
    {

    }

    void deposer(Ressource ressource, int quantite, Building building)
    {

    }

    void addElement(Ressource ressource)
    {

    }

    void setWorkingState()
    {

    }

    void setState(State state)
    {

    }
}
