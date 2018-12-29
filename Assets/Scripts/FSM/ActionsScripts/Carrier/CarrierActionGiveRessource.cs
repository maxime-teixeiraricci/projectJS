using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Carrier/Give Ressource")]
public class CarrierActionGiveRessource : FSMAction
{

    public override void Act(FSMControler controler)
    {
        give(controler);
    }

    public void give(FSMControler controler)
    {
        Citizen citizen = controler.GetComponent<Citizen>();
        citizen.refreshSoundBools();
        Building target = controler.finalTarget.GetComponent<Building>();
        foreach (RessourceTank rT in citizen.ressourcesToTransport.getRessourcesNeededTransport())
        {
            if (target.needRessources)
            {
                target.take(rT.ressource, citizen);
            }
        }

        foreach (Tool t in citizen.toolsToTransport.getToolsNeededTransport())
        {
            if (target.needTools)
            {
                target.takeTool(t, citizen);
            }
        }
    }
}
