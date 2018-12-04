using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camp : Building
{
    bool done = false;
    public bool enoughResourcesToCraft = false;

    [Header("Work")]
    public int numberWorkers;
    public List<Citizen> listWorkers;

    

    public void Start()
    {
        askSupplyToConstruct();
        Color colorStart = gameObject.GetComponent<MeshRenderer>().material.color;
        alphaColor = new Color(colorStart.r, colorStart.g, colorStart.b, 0);
        GetComponent<MeshRenderer>().material.color = alphaColor;
    }

    public void Update()
    {
        if (!done)
        {
            askSupplyToConstruct();
            Color colorStart = gameObject.GetComponent<MeshRenderer>().material.color;
            alphaColor = new Color(colorStart.r, colorStart.g, colorStart.b, 0);
            GetComponent<MeshRenderer>().material.color = alphaColor;
            done = true;
        }

        if (!isConstruct)
        {
            if (!enoughConstructToBuild)
            {
                askSupplyToConstruct();
            }
            else
            {
                askForConstructer();
                if (alphaColor.a >= 1.0)
                {
                    isConstruct = true;

                    foreach (RessourceTank r in inventory.getRessourcesNeededConstruct())
                    {
                        for (int i = 0; i < r.numberToConstruct; i++)
                        {
                            inventory.remove(r.ressource);
                        }

                    }
                }
            }
        }
    }

    //Called when a citizen need to drop his ressources
    public override void addRessource(GameObject ressource, int quantite)
    {
        for (int i = 0; i < quantite; i++)
        {
            Ressource r = ressource.GetComponent<RessourceContainer>().ressource;
            inventory.add(r);
        }
    }

    //Fading animation to represent building construction
    public override void construct()
    {
        Color colorStart = gameObject.GetComponent<MeshRenderer>().material.color;
        alphaColor = new Color(colorStart.r, colorStart.g, colorStart.b, colorStart.a + (1.0f / timeToBuild));
        GetComponent<MeshRenderer>().material.color = alphaColor;
    }

    public override void askForConstructer()
    {
        //Lors du placement du batiment il demande a être construit jusqu'à ce qu'il le soit
        //Demande au "camp de constructeurs" ou au dispacher
    }

    public void consommer()
    {
        //On consomme une ressource par habitant et par jour (à définir)
        //Si il n'y a plus de nourriture pour tenir le jour suivant, on appel askSupply
    }

    public void askSupplyToCraft()
    {
        // Demande la livrison de ressources, pour pouvoir construire des outils
        // Possiblement, demander un stock supérieur au strict minimum 
        // (Par exemple, demander 2x plus de ressources, pour éviter les changements incessants d'états)
        enoughResourcesToCraft = true;
    }

    public override void askSupplyToConstruct()
    {
        //Demande au "camp de transporteurs" ou au dispacher des ressources

        // La liste des ressources qu'il faut pour construire le batiment
        List<RessourceTank> ressourcesNeeded = inventory.getRessourcesNeededConstruct();

        foreach(RessourceTank r in ressourcesNeeded)
        {
            if(r.number < r.numberToConstruct)
            {
                int need = r.numberToConstruct - r.number;
                // TODO
                // Le dispatcher envoie une requête 
                //dispatcher.ask(Ressource, need);
            }
        }

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

    public override void take(Ressource ressource, Citizen citizen)
    {
        if (inventory.nbElementsTotal(ressource) < inventory.getLimit(ressource))
        {
            citizen.ressourcesToTransport.remove(ressource);
            inventory.add(ressource);
        }
    }

    public void HireWorker(Citizen citizen)
    {
        if (numberWorkers < listWorkers.Count)
        {
            listWorkers.Add(citizen);
            citizen.workPlace = this;
        }
    }

    public void FireWorker(Citizen citizen)
    {
        if (listWorkers.Contains(citizen))
        {
            listWorkers.Remove(citizen);
            citizen.workPlace = null;
        }
    }


    public override void give(Ressource ressource, Citizen citizen)
    {
        if (inventory.nbElementsTotal(ressource) > 0)
        {
            citizen.ressourcesToTransport.add(ressource);
            inventory.remove(ressource);
        }

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

    private void OnTriggerEnter(Collider other)
    {
        if (!isPlaced)
        {
            GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0, 155);
            goodPosition = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isPlaced)
        {
            GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0, 155);
            goodPosition = true;
        }
    }
}
