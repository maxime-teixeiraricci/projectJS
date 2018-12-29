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
        Citizen citizen = controler.GetComponent<Citizen>();
        citizen.refreshSoundBools();
        citizen.isBuilding = true;

        if (!controler.target) return;
        Building building = controler.target.GetComponent<Building>();
        if (!building) return;
        if(building.enoughConstructToBuild && building.enoughToolsToBuild && !building.isConstruct)
        {
            building.construct(controler.citizen);
        }
        
    }

    public float bonusLevel(int level)
    {
        return Mathf.Sqrt(level) * 0.5f + 0.5f;
    }
}
