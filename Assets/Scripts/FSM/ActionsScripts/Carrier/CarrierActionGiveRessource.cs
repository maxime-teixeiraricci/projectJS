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
        Building target = controler.finalTarget.GetComponent<Building>();
        Citizen citizen = controler.GetComponent<Citizen>();
        foreach (RessourceTank rT in citizen.ressourcesToTransport.getRessourcesNeededTransport())
        {
            target.take(rT.ressource, citizen);
        }
    }
}
