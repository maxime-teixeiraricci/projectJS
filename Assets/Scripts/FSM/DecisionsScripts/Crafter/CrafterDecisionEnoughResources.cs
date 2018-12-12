using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Crafter/Enough Resources")]
public class CrafterDecisionEnoughResources : FSMDecision
{

    public override bool Decide(FSMControler controler)
    {
        return HaveEnoughResources(controler);
    }

    public bool HaveEnoughResources(FSMControler controler)
    {
        if (!controler.target) return false;
        //Camp building = controler.target.gameObject.GetComponent<Camp>();
        //if (!building) return false;

        // L'outil à construire
        Tool tool = controler.target.GetComponent<ToolInventory>().activeTool;

        // La ressource qu'il faut pour le construire
        Ressource ressource = tool.ressourceNeeded;

        // Le nombre de cette ressource qu'il faut
        int nbrRessource = tool.numberRessourcesNeeded;
        // Le nombre de la ressource contenu dans le batiment
        int stockRessource = controler.target.GetComponent<RessourceInventory>().nbElementsTotal(ressource);

        return (stockRessource >= nbrRessource);
    }
}