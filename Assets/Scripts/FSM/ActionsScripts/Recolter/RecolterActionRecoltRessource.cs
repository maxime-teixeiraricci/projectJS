﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Recolter/Recolt")]
public class RecolterActionRecoltRessource : FSMAction
{
    
    public override void Act(FSMControler controler)
    {
        Recolt(controler);
    }

    private void Recolt(FSMControler controler)
    {
        Citizen citizen = controler.GetComponent<Citizen>();
        citizen.refreshSoundBools();
        citizen.isRecoltWood = true;
        if (!controler.target) return;
        NaturalRessource naturalRessource = controler.target.GetComponent<NaturalRessource>();
        if (!naturalRessource) return;

        /*// Regarde le niveau de compétence du villageois
        if (!controler.citizen.competences.ContainsKey(naturalRessource.nameCompetence))
        {
            controler.citizen.competences[naturalRessource.nameCompetence] = 1;
        }
        int level = controler.citizen.competences[naturalRessource.nameCompetence];
        float citizenFrequence = naturalRessource.recoltFrequence * bonusLevel(level);
        //Debug.Log(1f / citizenFrequence);*/
        if (controler.farmTimer > (1f/ naturalRessource.recoltFrequence))
        {
            naturalRessource.Recolt(controler.citizen);
            Text woodText = GameObject.Find("WoodTotal").GetComponent<Text>();
            woodText.text = (int.Parse(woodText.text) + 1).ToString();
            controler.farmTimer = 0;
        }
        else
        {
            controler.farmTimer += Time.deltaTime;
        }
    }

    public float bonusLevel(int level)
    {
        return Mathf.Sqrt(level) * 0.5f + 0.5f;
    }
}
