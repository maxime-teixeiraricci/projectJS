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
