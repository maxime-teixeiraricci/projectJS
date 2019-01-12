using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Recolter/FindRessource")]
public class RecolterActionFindRessource : FSMAction
{
    public override void Act(FSMControler controler)
    {
        FindRessource(controler);
    }

    private void FindRessource(FSMControler controler)
    {
        Citizen citizen = controler.GetComponent<Citizen>();
        if (citizen.ressourcesToTransport.ressourcesList.Count != 0)
        {
            citizen.ressourcesToTransport.ressourcesList[0].neededToTransport = true;
            citizen.ressourcesToTransport.ressourcesList[0].numberLimit = 5;
        }
        citizen.refreshSoundBools();
        GameObject ressourceTank = GameObject.FindGameObjectWithTag("RessourceTank");
        if(controler.manualTarget == null)
        {
            if (ressourceTank)
            {
                controler.target = ressourceTank;
            }
            else
            {
                ressourceTank = GameObject.FindGameObjectWithTag("Camp");
                controler.target = ressourceTank;
            }
        }
        else
        {
            controler.target = controler.manualTarget;
        }
        
    }


}
