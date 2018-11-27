using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Builder/Build")]
public class BuilderActionBuild : FSMAction
{

    public override void Act(FSMControler controler)
    {
        Build(controler);
    }

    private void Build(FSMControler controler)
    {
        // TODO
    }

}
