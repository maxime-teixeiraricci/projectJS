using System.Collections;
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
        // TODO
    }

}
