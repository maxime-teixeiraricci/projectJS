using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Recolter/Walk To Ressource")]
public class RecolterActionWalkToRessource : FSMAction
{

    public override void Act(FSMControler controler)
    {
        if (!controler.target || !controler.target.CompareTag("RessourceTank"))
        {
            FindRessource(controler);
        }
        
        WalkTowardsRessource(controler);
    }

    private void WalkTowardsRessource(FSMControler controler)
    {
        if (controler.target)
        {
            Citizen citizen = controler.GetComponent<Citizen>();
            citizen.refreshSoundBools();
            citizen.isWalking = true;
            controler.agent.SetDestination(controler.target.transform.position);
        }
    }

    private void FindRessource(FSMControler controler)
    {
        GameObject ressourceTank = GameObject.FindGameObjectWithTag("RessourceTank");
        if (ressourceTank)
        {
            controler.target = ressourceTank;
        }
    }
}
