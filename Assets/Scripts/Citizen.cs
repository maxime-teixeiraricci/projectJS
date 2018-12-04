using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour {

    public enum Group {None, Transport, Collect, Product, Construct};
    enum Etats { Sain, Malade, Mort };

    public RessourceInventory ressourcesToTransport;

    Dictionary<Ressource, int> capacitesInventaire;
    [HideInInspector] public Dictionary<Ressource, int> inventaire = new Dictionary<Ressource, int>();

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

    public Building workPlace;
    public CitizenSetting citizenSetting;
    [Header("Group")]
    public Group group = Group.None;
    public MeshRenderer citizenShirt;


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

    public void ChangeGroup(Group newGroup)
    {
        if (newGroup != group)
        {
            group = newGroup;

            foreach (GroupIdleState gis in citizenSetting.idleGroupState)
            {
                if (gis.group == group)
                {
                    GetComponent<FSMControler>().target = null;
                    GetComponent<FSMControler>().agent.isStopped = false;
                    GetComponent<FSMControler>().agent.destination = transform.position;
                    GetComponent<FSMControler>().currentState = gis.idleState;
                    return;
                }
            }
        }
    }

    public void SeekForJob()
    {
        if (group == Group.Collect && 
            !workPlace &&
            canWork && 
            !DispatcherManager.instance.gatherersJobless.Contains(this))
        {
            DispatcherManager.instance.gatherersJobless.Add(this);
        }
    }

    private void Update()
    {
        SeekForJob();
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

        switch(group)
        {
            case Group.None:
                citizenShirt.material.color = Color.black;
                break;
            case Group.Transport:
                citizenShirt.material.color = Color.blue;
                break;
            case Group.Collect:
                citizenShirt.material.color = Color.green;
                break;
            case Group.Product:
                citizenShirt.material.color = Color.red;
                break;
            case Group.Construct:
                citizenShirt.material.color = Color.yellow;
                break;
        }
    }
}
