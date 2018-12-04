using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Carrier/Go To Camp With Resources")]
public class CarrierActionGoToCampWithRessources : FSMAction
{
    public override void Act(FSMControler controler)
    {
        FindRessource(controler);
    }

    private void FindRessource(FSMControler controler)
    {
        GameObject[] shelterList = GameObject.FindGameObjectsWithTag("Camp");
        controler.target = null;
        if (shelterList.Length > 0)
        {
            foreach (GameObject gO in shelterList)
            {
                if (gO.GetComponent<Building>().isConstruct)
                {
                    Building building = gO.GetComponent<Building>();
                    foreach (RessourceTank rT in controler.GetComponent<Citizen>().ressourcesToTransport.ressourcesList)
                    {
                        if (building.inventory.nbElementsTotal(rT.ressource) > 0)
                        {
                            controler.target = gO;
                            return;
                        }
                    }
                }
                
            }
        }

        controler.target = null;

    }


}
