using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Building : MonoBehaviour {

    //building inventory
    public RessourceInventory inventory;//= new RessourceInventory();
    public bool needRessources;
    public bool needTools;
    public ToolInventory toolsInventory;
    //isConstruct
    public bool isConstruct = false;
    public bool enoughToolsToBuild = false;
    public bool enoughConstructToBuild = false;
    public bool isPlaced = false;
    public bool goodPosition;

    public MeshRenderer mesh;

    public ResourcesCount totalNbr;
    
    public float buildFrequence = 1.0f;

    public Color alphaColor;
    // Temps qu'il faut pour construire le batiment
    public float timeToBuild = 5.0f;
    public float passedTimedBuild;
    //building level
    int niveau;
    //building attached citizens list
    List<Citizen> citizens;
    //Competence builder
    public string nameCompetence;
    //abstract public List<RessourceTank> getRessourcesNeeded();

    public TextMesh progressionBuild;
    public Text toolText;

    private void Start()
    {
        toolText = GameObject.FindGameObjectWithTag("ToolText").GetComponent<Text>();
    }

    private void Update()
    {
        toolText = GameObject.FindGameObjectWithTag("ToolText").GetComponent<Text>();
    }
    public List<RessourceTank> resosurcesNeededForConstruct()
    {
        List<RessourceTank> res = new List<RessourceTank>();
        foreach (RessourceTank r in inventory.ressourcesList)
        {
            if (r.neededToConstruct) res.Add(r);
        }
        return res;
    }

    public List<Tool> toolsNeededForConstruct()
    {
        List<Tool> res = new List<Tool>();
        foreach (Tool t in toolsInventory.toolInventory)
        {
            if (t.neededToConstruct) res.Add(t);
        }
        return res;
    }
    /*
    //Called when a citizen need to drop his ressources
    public void addRessource(GameObject ressource, int quantite)
    {
        for (int i = 0; i < quantite; i++)
        {
            Ressource r = ressource.GetComponent<RessourceContainer>().ressource;
            inventory.add(r);
            totalNbr.Add(r);
        }
    }
    */
    //Fading animation to represent building construction
    public void construct(Citizen citizen)
    {
        Color colorStart = gameObject.GetComponent<MeshRenderer>().material.color;
        passedTimedBuild += Time.deltaTime;
        alphaColor = new Color(colorStart.r, colorStart.g, colorStart.b, colorStart.a + Time.deltaTime);
        GetComponent<MeshRenderer>().material.color = alphaColor;
        progressionBuild.text = ((int)(passedTimedBuild / timeToBuild * 100)).ToString() + "%";
        //Debug.Log("value % alpha = " + passedTimedBuild / timeToBuild * 100);
    }

    public void askSupplyToConstruct()
    {
        //Demande au "camp de transporteurs" ou au dispacher des ressources

        // La liste des ressources qu'il faut pour construire le batiment
        List<RessourceTank> ressourcesNeeded = inventory.getRessourcesNeededConstruct();

        //S'il y a assez de constructions, on le signal
        enoughConstructToBuild = true;
        foreach (RessourceTank r in ressourcesNeeded)
        {
            if (r.number < r.numberToConstruct && !isConstruct)
            {
                enoughConstructToBuild = false;
            }
        }

        List<Tool> toolsNeeded = toolsInventory.getToolsNeededConstruct();

        enoughToolsToBuild = true;
        foreach (Tool t in toolsNeeded)
        {
            if (t.number < t.nbToConstruct && !isConstruct)
            {
                enoughToolsToBuild = false;
            }
        }
    }

    public void take(Ressource ressource, Citizen citizen)
    {
        if (inventory.nbElementsTotal(ressource) < inventory.getLimit(ressource) && citizen.ressourcesToTransport.nbElementsTotal(ressource)>0)
        {
            citizen.ressourcesToTransport.remove(ressource);
            inventory.add(ressource);
            totalNbr.Add(ressource);
        }
        askSupplyToConstruct();

        if (enoughConstructToBuild)
        {
            needRessources = false;
        }
        if (enoughToolsToBuild)
        {
            needTools = false;
        }
    }

    public void takeTool(Tool tool, Citizen citizen)
    {
        if (toolsInventory.nbElementsTotal(tool) < toolsInventory.getLimit(tool) && citizen.toolsToTransport.nbElementsTotal(tool) > 0)
        {
            citizen.toolsToTransport.remove(tool);
            toolsInventory.add(tool);
        }
        askSupplyToConstruct();

        if (enoughToolsToBuild)
        {
            needTools = false;
        }
        if (enoughConstructToBuild)
        {
            needRessources = false;
        }
    }

    public void give(Ressource ressource, Citizen citizen)
    {
        if (inventory.nbElementsTotal(ressource) > 0)
        {
            citizen.ressourcesToTransport.add(ressource);
            inventory.remove(ressource);
            //totalNbr.Remove(ressource);
            totalNbr.Remove(ressource);
        }
    }

    public void giveTool(Tool tool, Citizen citizen)
    {
        if (toolsInventory.nbElementsTotal(tool) > 0)
        {
            citizen.toolsToTransport.add(tool);
            toolsInventory.remove(tool);
            //totalNbr.Remove(ressource);
            //totalNbr.Remove(tool);
        }
        else { Debug.Log("Tool not in inventory "+tool.name); }
    }


    public List<RessourceTank> getRessourcesNeeded()
    {
        List<RessourceTank> ressourcesNeeded = inventory.getRessourcesNeededConstruct();
        List<RessourceTank> res = new List<RessourceTank>();

        foreach (RessourceTank r in ressourcesNeeded)
        {
            if (r.number < r.numberToConstruct)
            {

                int need = r.numberToConstruct - r.number;
                res.Add(r);
            }
        }

        return res;
    }

    public List<Tool> getToolsNeeded()
    {
        List<Tool> toolsNeeded = toolsInventory.getToolsNeededConstruct();
        List<Tool> res = new List<Tool>();

        foreach (Tool t in toolsNeeded)
        {
            if (t.number < t.nbToConstruct)
            {

                int need = t.nbToConstruct - t.number;
                res.Add(t);
            }
        }

        return res;
    }

    private void OnTriggerEnter(Collider other)
    {

        // Mauvais collide : On entre en contact avec un item de la map
        if (!isPlaced)
        {
            mesh.material.color = new Color(255, 0, 0, 155);
            goodPosition = false;
        }

        // Good Collide : le poitneur de la souris entre sur le terrain
        if (!isPlaced && other == GameObject.Find("Plane").GetComponent<MeshCollider>())
        {
            mesh.material.color = new Color(0, 255, 0, 155);
            goodPosition = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        // Bon exit : On sort de la collision genante
        if (!isPlaced)
        {
            mesh.material.color = new Color(0, 255, 0, 155);
            goodPosition = true;
        }

        // Mauvais collide : On sort de la map
        if (!isPlaced && other == GameObject.Find("Plane").GetComponent<MeshCollider>())
        {
            mesh.material.color = new Color(255, 0, 0, 155);
            goodPosition = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // si lorsqu'on quitte un collider, on entre dans un autre collider, notre objet reste alors impossible à placer.
        // On applique cette vérification uniquement aux batiments qui ne sont pas encore placés.
        // On vérifie bien de ne pas prendre en compte la collision avec le terrain
        if (!isPlaced && other != GameObject.Find("Plane").GetComponent<MeshCollider>())
        {
            mesh.material.color = new Color(255, 0, 0, 155);
            goodPosition = false;
        }
    }
}

