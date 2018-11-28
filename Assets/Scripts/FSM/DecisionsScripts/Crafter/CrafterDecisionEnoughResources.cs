﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Crafter/Enough Resources")]
public class CrafterDecisionEnoughResources : FSMDecision {

    public override bool Decide(FSMControler controler)
    {
        return HaveEnoughResources(controler);
    }

    public bool HaveEnoughResources(FSMControler controler)
    {
        // TODO : Récupérer la taille de la liste Value associée à notre ressource
        return (controler.target.GetComponent<Building>().stock.Count > 0);
    }
}