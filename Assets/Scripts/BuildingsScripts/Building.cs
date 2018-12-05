using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour {

    //building inventory
    public RessourceInventory inventory;//= new RessourceInventory();
    public bool needRessource;
    //isConstruct
    public bool isConstruct = false;
    public bool enoughConstructToBuild = false;
    public bool isPlaced = false;
    public bool goodPosition;
    
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
    abstract public void askForConstructer();
    //abstract public List<RessourceTank> getRessourcesNeeded();

    public List<RessourceTank> resosurcesNeededForConstruct()
    {
        List<RessourceTank> res = new List<RessourceTank>();
        foreach (RessourceTank r in inventory.ressourcesList)
        {
            if (r.neededToConstruct) res.Add(r);
        }
        return res;
    }

    //Called when a citizen need to drop his ressources
    public void addRessource(GameObject ressource, int quantite)
    {
        for (int i = 0; i < quantite; i++)
        {
            Ressource r = ressource.GetComponent<RessourceContainer>().ressource;
            inventory.add(r);
        }
    }

    //Fading animation to represent building construction
    public void construct()
    {
        Color colorStart = gameObject.GetComponent<MeshRenderer>().material.color;
        alphaColor = new Color(colorStart.r, colorStart.g, colorStart.b, colorStart.a + (1.0f / timeToBuild));
        GetComponent<MeshRenderer>().material.color = alphaColor;
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
            if (r.number < r.numberToConstruct)
            {
                enoughConstructToBuild = false;
            }
        }
    }

    public void take(Ressource ressource, Citizen citizen)
    {
        if (inventory.nbElementsTotal(ressource) < inventory.getLimit(ressource))
        {
            citizen.ressourcesToTransport.remove(ressource);
            inventory.add(ressource);
        }
        askSupplyToConstruct();

        if (enoughConstructToBuild)
        {
            needRessource = false;
        }
        if (GetComponent<ToolInventory>())
        {
            // L'outil à construire
            Tool tool = GetComponent<ToolInventory>().activeTool;
            // La ressource qu'il faut pour le construire
            Ressource resNeed = tool.ressourceNeeded;

            // Le nombre de cette ressource qu'il faut
            int nbrRessource = tool.numberRessourcesNeeded;

            // Le nombre de la ressource contenu dans le batiment
            int stockRessource = GetComponent<RessourceInventory>().nbElementsTotal(ressource);

            if (stockRessource >= nbrRessource)
            {
                needRessource = false;
            }
        }
    }

    public void give(Ressource ressource, Citizen citizen)
    {
        if (inventory.nbElementsTotal(ressource) > 0)
        {
            citizen.ressourcesToTransport.add(ressource);
            inventory.remove(ressource);
        }
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

    private void OnTriggerEnter(Collider other)
    {

        // Mauvais collide : On entre en contact avec un item de la map
        if (!isPlaced)
        {
            GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0, 155);
            goodPosition = false;
        }

        // Good Collide : le poitneur de la souris entre sur le terrain
        if (!isPlaced && other == GameObject.Find("Plane").GetComponent<MeshCollider>())
        {
            GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0, 155);
            goodPosition = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        // Bon exit : On sort de la collision genante
        if (!isPlaced)
        {
            GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0, 155);
            goodPosition = true;
        }

        // Mauvais collide : On sort de la map
        if (!isPlaced && other == GameObject.Find("Plane").GetComponent<MeshCollider>())
        {
            GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0, 155);
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
            GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0, 155);
            goodPosition = false;
        }
    }
}

