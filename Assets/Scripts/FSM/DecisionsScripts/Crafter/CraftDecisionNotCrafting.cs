using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Crafter/Not Crafting")]
public class CraftDecisionNotCrafting : FSMDecision {


    public override bool Decide(FSMControler controler)
    {
        return !controler.citizen.isCraftingTool;
    }
}
