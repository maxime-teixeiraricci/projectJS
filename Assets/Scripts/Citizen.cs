using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Citizen : MonoBehaviour {

    public enum Group {None, Transport, Collect, Product, Construct};
    enum Etats { Sain, Malade, Mort };

    public RessourceInventory ressourcesToTransport;
    public ToolInventory toolsToTransport;
    public float coefBuild = 1.0f;
    Dictionary<Ressource, int> capacitesInventaire;
    [HideInInspector] public Dictionary<Ressource, int> inventaire = new Dictionary<Ressource, int>();

    public List<GameObject> ressources;

    public Dictionary<string, int> competences = new Dictionary<string, int>();

    public float age;

    public bool isFull;
    public bool canWork;
    public bool isWalking;
    public bool isProductTool;
    public bool isRecoltWood;
    public bool isBuilding;

    public AudioSource walk;

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

    public TextMesh nbWoodText;
    public TextMesh nbToolText;

    public void refreshSoundBools()
    {
            isWalking = false;
            isProductTool = false;
            isRecoltWood = false;
            isBuilding = false;
    }

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

    public void setFSMSounds()
    {
        List<string> soundParameters = new List<string>();
        soundParameters.Add("Walk");
        soundParameters.Add("Recolt");
        soundParameters.Add("ToolProduction");
        soundParameters.Add("Construct");
        bool isSoundNeeded;
        foreach (string param in soundParameters)
        {
            isSoundNeeded = false;
            switch (param)
            {
                case "Walk":
                    isSoundNeeded = isWalking;
                    break;
                case "Recolt":
                    isSoundNeeded = isRecoltWood;
                    break;
                case "ToolProduction":
                    isSoundNeeded = isProductTool;
                    break;
                case "Construct":
                    isSoundNeeded = isBuilding;
                    break;
                default:
                    break;
            }
            if (isSoundNeeded)
            {
                FMODUnity.StudioEventEmitter emitter = GetComponent<FMODUnity.StudioEventEmitter>();
                emitter.enabled = true;
                FMOD.Studio.ParameterInstance parameter;
                emitter.EventInstance.getParameter(param, out parameter);
                if (!parameter.Equals(null))
                {
                    parameter.setValue(1.0f);
                }
            }
            else
            {
                FMODUnity.StudioEventEmitter emitter = GetComponent<FMODUnity.StudioEventEmitter>();
                FMOD.Studio.ParameterInstance parameter;
                emitter.EventInstance.getParameter(param, out parameter);
                if (!parameter.Equals(null))
                {
                    parameter.setValue(0.0f);
                }
                if (!isWalking && !isBuilding && !isProductTool && !isRecoltWood) {
                    emitter.enabled = false;
                }
            }
        }
        
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
            print("A");
            DispatcherManager.instance.gatherersJobless.Add(this);
        }
    }

    private void Update()
    {
        SeekForJob();
        setFSMSounds();
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

        if (ressourcesToTransport.ressourcesList.Count != 0)
        {
            nbWoodText.text = ressourcesToTransport.ressourcesList[0].number.ToString();
        }
        if (toolsToTransport.toolInventory.Count != 0)
        {
            nbToolText.text = toolsToTransport.toolInventory[0].number.ToString();
        }
    }
}
