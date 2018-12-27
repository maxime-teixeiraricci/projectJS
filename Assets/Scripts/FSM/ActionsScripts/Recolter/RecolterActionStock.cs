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

   /* private void Stock(FSMControler controler)
    {
        if (controler.target.GetComponent<Building>() && controler.citizen.ressources.Count != 0)
        {
            controler.target.GetComponent<Building>().addRessource(controler.citizen.ressources[0], 1);
            controler.citizen.ressources.RemoveAt(0);
        }
    }
    */
    private void Stock(FSMControler controler)
    {
        Building target = controler.citizen.workPlace.GetComponent<Building>();
        Citizen citizen = controler.GetComponent<Citizen>();
        citizen.isWalking = false;
        foreach (RessourceTank rT in citizen.ressourcesToTransport.getRessourcesNeededTransport())
        {
            target.take(rT.ressource, citizen);
        }
    }
}
