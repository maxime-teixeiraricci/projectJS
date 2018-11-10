using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour {

    enum Groupes { Recolteur, Transporteur, Producteur};
    enum Etats { Sain, Malade, Mort };

    Dictionary<Ressource, int> capacitesInventaire;
    Dictionary<Ressource, int> inventaire = new Dictionary<Ressource, int>();

    public List<GameObject> ressources;

    public Dictionary<string, int> competences = new Dictionary<string, int>();

    public float age;

    public bool isFull;
    public bool canWork;

    public int soifMax;
    public int faimMax;
    public int vieMax;

    public int soifCourante;
    public int faimCourante;
    public int vieCourante;
    public CitizenSetting citizenSetting;


    void consommer(Ressource ressource)
    {

    }

    void deposer(Ressource ressource, int quantite, Building building)
    {
        foreach (GameObject r in ressources)
        {

        }
    }

    public void addRessource(GameObject ressource)
    {
        
        if (ressources.Contains(ressource)) return;
        ressources.Add(ressource);
    }

    void setWorkingState()
    {

    }

    void setState(Etats state)
    {

    }

    private void Update()
    {
        for (int i=0; i < ressources.Count; i ++)
        {
            if (i == 0)
            {
                ressources[i].transform.position += (transform.position - ressources[i].transform.position) * 0.25f;
            }
            else
            {
                ressources[i].transform.position += (ressources[i-1].transform.position - ressources[i].transform.position) * 0.25f;
            }
        }
    }
}
