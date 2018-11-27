using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Recolter/Walk To Shelter")]
public class RecolterActionWalkToBuilding : FSMAction
{

    public override void Act(FSMControler controler)
    {
        if (!controler.target || !controler.target.CompareTag("Batiment"))
        {
            FindShelter(controler);
        }

        WalkTowardsTarget(controler);
    }

    private void WalkTowardsTarget(FSMControler controler)
    {
        controler.agent.SetDestination(controler.target.transform.position);
    }

    private void FindShelter(FSMControler controler)
    {
        GameObject shelter = GameObject.FindGameObjectWithTag("Batiment");
        if (shelter)
        {
            controler.target = shelter;
        }
    }
}
