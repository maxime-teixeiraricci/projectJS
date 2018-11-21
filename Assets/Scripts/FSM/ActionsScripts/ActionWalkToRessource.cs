using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Walk To Ressource")]
public class ActionWalkToRessource : FSMAction
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
