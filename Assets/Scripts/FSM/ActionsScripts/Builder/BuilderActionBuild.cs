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
        if (!controler.target) return;
        Building building = controler.target.GetComponent<Building>();
        if (!building) return;

        // Regarde le niveau de compétence du villageois
        if (!controler.citizen.competences.ContainsKey(building.nameCompetence))
        {
            controler.citizen.competences[building.nameCompetence] = 1;
        }
        //Niveau du citoyen
        int level = controler.citizen.competences[building.nameCompetence];
        //Frequence de construction du citoyen
        float citizenFrequence = building.buildFrequence * bonusLevel(level);
        //si le temps passé à construire est 
        if (controler.buildTimer > (1f / citizenFrequence))
        {
            building.construct();
            controler.buildTimer = 0;
        }
        else
        {
            controler.buildTimer += Time.deltaTime;
        }
    }

    public float bonusLevel(int level)
    {
        return Mathf.Sqrt(level) * 0.5f + 0.5f;
    }
}
