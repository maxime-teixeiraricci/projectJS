using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Recolter/Stock")]
public class RecolterActionStock : FSMAction
{

    public override void Act(FSMControler controler)
    {
        Stock(controler);
    }

    private void Stock(FSMControler controler)
    {
        if (controler.target.GetComponent<Building>() && controler.citizen.ressources.Count != 0)
        {
            controler.target.GetComponent<Building>().addRessource(controler.citizen.ressources[0], 1);
            controler.citizen.ressources.RemoveAt(0);
        }
    }

}
