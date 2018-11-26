using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Recolter/Target Ressource")]
public class RecolterDecisionTargetRessource : FSMDecision {

    public override bool Decide(FSMControler controler)
    {
        return HaveTarget(controler);
    }

    public bool HaveTarget(FSMControler controler)
    {
        if (controler.target != null)
        {
           return (controler.target.gameObject.tag == "RessourceTank");
        }

        return false;
    }
}
