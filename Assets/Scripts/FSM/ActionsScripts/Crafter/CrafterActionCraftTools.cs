﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Crafter/CraftTools")]
public class CrafterActionCraftTools : FSMAction
{

    public override void Act(FSMControler controler)
    {
        Craft(controler);
    }

    private void Craft(FSMControler controler)
    {
        Citizen citizen = controler.GetComponent<Citizen>();
        citizen.refreshSoundBools();
        citizen.isProductTool = true;

        if (!controler.target) return;
        Building building = controler.target.GetComponent<Building>();
        if (!building) return;
        Tool tool = building.GetComponent<ToolInventory>().activeTool;
        // TEMPORAIRE. Récupération du 1er outil dispo dans la liste
        //Tool tool = building.toolsStock.Keys.;
        

        // Regarde le niveau de compétence du villageois
        if (!controler.citizen.competences.ContainsKey(building.nameCompetence))
        {
            controler.citizen.competences[building.nameCompetence] = 1;
        }
        /*
        //Niveau du citoyen
        int level = controler.citizen.competences[building.nameCompetence];
        //Frequence de construction du citoyen
        float citizenFrequence = building.timeToBuild * bonusLevel(level);
        //si le temps passé à construire est 
        */
        /*if (!building.GetComponent<ToolInventory>().isCrafted())
        {
            building.GetComponent<ToolInventory>().isGettingCrafted();
        }

        else
        {
            building.GetComponent<ToolInventory>().addTool();
            building.GetComponent<ToolInventory>().add(tool);
            for (int i = 0; i < tool.numberRessourcesNeeded; i++)
            {
                building.GetComponent<RessourceInventory>().remove(tool.ressourceNeeded);
            }
            
        }*/

        if (!controler.citizen.isCraftingTool && building.inventory.nbElementsTotal(tool.ressourceNeeded)>=tool.numberRessourcesNeeded)
        {
            controler.citizen.product(tool, building);
        }

    }

    public float bonusLevel(int level)
    {
        return Mathf.Sqrt(level) * 0.5f + 0.5f;
    }

}
