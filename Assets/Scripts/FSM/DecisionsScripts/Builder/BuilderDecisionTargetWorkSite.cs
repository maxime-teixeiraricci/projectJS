using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Builder/Target Work Site")]
public class BuilderDecisionTargetWorkSite : FSMDecision
{

    public override bool Decide(FSMControler controler)
    {
        return HaveTarget(controler);
    }

    public bool HaveTarget(FSMControler controler)
    {
        if (!controler.target) return false;

        // On retounre en priorité la manualTarget si elle existe
        if(controler.manualTarget != null)
        {
            return controler.manualTarget.gameObject.GetComponent<Building>();
        }

        else
        {
            return controler.target.gameObject.GetComponent<Building>();
        } 
    }
}
