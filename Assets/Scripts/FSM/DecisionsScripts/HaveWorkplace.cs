using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/HaveWorkplace")]
public class HaveWorkplace : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return haveWorkPlace(controler);
    }

    private bool haveWorkPlace(FSMControler controler)
    {
        return controler.citizen.workPlace != null;
    }
}
