using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Carrier/Gather Resources")]
public class CarrierActionGatherResources : FSMAction
{

    public override void Act(FSMControler controler)
    {
        GatherResources(controler);
    }

    private void GatherResources(FSMControler controler)
    {
        //controler.citizen.addRessource(ressource)    Ajouter la ressource dans le sac du carrier

        //foreach(Ressource item in controler.target.GetComponent<Building>().ressourcesNeeded.Values)
        /*
        for(int i = 0; i < controler.target.GetComponent<Building>().ressourcesNeeded.Values.Count; i++)
        {
            controler.citizen.addRessource(controler.target.GetComponent<Building>().ressourcesNeeded.Keys.)
        }*/
    }

}
