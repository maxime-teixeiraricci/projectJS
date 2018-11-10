using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Recolt")]
public class ActionRecoltRessource : FSMAction
{
    
    public override void Act(FSMControler controler)
    {
        Recolt(controler);
    }

    private void Recolt(FSMControler controler)
    {
        NaturalRessource naturalRessource = controler.target.GetComponent<NaturalRessource>();
        if (!naturalRessource) return;

        // Regarde le niveau de compétence du villageois
        if (!controler.citizen.competences.ContainsKey(naturalRessource.nameCompetence))
        {
            controler.citizen.competences[naturalRessource.nameCompetence] = 1;
        }
        int level = controler.citizen.competences[naturalRessource.nameCompetence];
        float citizenFrequence = naturalRessource.recoltFrequence * bonusLevel(level);

        if (controler.farmTimer > (1f/ citizenFrequence))
        {

        }
    }

    public float bonusLevel(int level)
    {
        return Mathf.Sqrt(level) * 0.5f + 0.5f;
    }
}
