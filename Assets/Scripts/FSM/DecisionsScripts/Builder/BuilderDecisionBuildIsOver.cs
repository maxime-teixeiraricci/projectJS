using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Builder/Build Is Over")]
public class BuilderDecisionBuildIsOver : FSMDecision
{
    public override bool Decide(FSMControler controler)
    {
        return BuildIsOver(controler);
    }

    private bool BuildIsOver(FSMControler controler)
    {
        controler.target.GetComponent<Building>().progressBuild += 1;
        // Si le temps passé à construire le batiment est égal au temps nécessaire pour la construction, on retourne True
        return (controler.target.GetComponent<Building>().progressBuild == controler.target.GetComponent<Building>().timeToBuild);
    }
}
