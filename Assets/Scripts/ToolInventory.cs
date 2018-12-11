using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolInventory : MonoBehaviour {

    [HideInInspector] public Dictionary<Tool, int> toolStock = new Dictionary<Tool, int>();

    public List<Tool> toolInventory;

    // L'outil qui sera produit
    public Tool activeTool;

    public int nbrTools = 0;

    public Text wood;
    public Text toolCount;

    float timeCrafted = 0;

	// Use this for initialization
	void Start ()
    {
		foreach(Tool tool in toolInventory)
        {
            if (!toolStock.ContainsKey(tool))
            {
                toolStock.Add(tool, 0);
            }
        }
        if (toolInventory.Count > 0)
        {
            activeTool = toolInventory[0];
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addTool()
    {
        toolStock[activeTool] += 1;
        nbrTools = toolStock[activeTool];
    }

    public void removeTool()
    {
        toolStock[activeTool] -= 1;
    }

    public Tool getActiveTool()
    {
        return activeTool;
    }

    public void setActiveTool(Tool tool)
    {
        activeTool = tool;
    }

    public void isGettingCrafted()
    {
        timeCrafted += 1.0f / activeTool.timeToCraft;
    }

    public bool isCrafted()
    {
        if(timeCrafted >= activeTool.timeToCraft)
        {
            timeCrafted = 0;
            wood.text = (int.Parse(wood.text) - activeTool.numberRessourcesNeeded).ToString();
            toolCount.text = (int.Parse(toolCount.text) + 1).ToString();
            return true;
        }
        
        return false;
    }

    public static Tool NULL = null;

    public Tool getStruct(Tool tool)
    {
        //print(ressourcesList.Count);
        foreach (Tool t in toolInventory)
        {
            //print(ressource.name + " - " + rT.ressource.name);
            if (t.index == tool.index)
            {
                return t;
            }
        }
        return ToolInventory.NULL;
    }

    public bool contain(Tool tool)
    {
        return !getStruct(tool).Equals(ToolInventory.NULL);
    }

    public int nbElementsTotal(Tool tool)
    {
        Tool rT = getStruct(tool);
        if (!rT.Equals(ToolInventory.NULL))
        {
            return rT.number;
        }
        else
        {
            return 0;
        }
    }

    public List<Tool> getToolsNeededConstruct()
    {
        List<Tool> res = new List<Tool>();
        if (!toolInventory.Equals(new List<Tool>()))
        {
            foreach (Tool t in toolInventory)
            {
                if (t.neededToConstruct)
                {
                    res.Add(t);
                }
            }
        }
        return res;
    }


    public List<Tool> getToolsNeededTransport()
    {
        List<Tool> res = new List<Tool>();
        foreach (Tool t in toolInventory)
        {
            if (t.neededToTransport)
            {
                res.Add(t);
            }
        }
        return res;
    }

    public void remove(Tool tool)
    {
        Tool t = getStruct(tool);
        //numberRessources = rT.number;
        if (!t.Equals(ToolInventory.NULL))
        {
            if (t.number > 0)
            {
                t.number = t.number - 1;
                //print(nbElementsTotal(ressource));





                //numberRessources = numberRessources - 1;
                //rT.number = numberRessources;
                //print(rT.number);
                //return true;
            }
        }
        //return false;
    }

    public int getLimit(Tool tool)
    {
        Tool t = getStruct(tool);
        if (!t.Equals(ToolInventory.NULL))
        {
            return t.numberLimit;
        }
        return -1;
    }

    public void add(Tool tool)
    {
        Tool t = getStruct(tool);
        if (!t.Equals(ToolInventory.NULL))
        {
            t.number = t.number + 1;
            if (tool.nbToConstruct != -1)
            {
                t.nbToTransport = tool.nbToConstruct;
                t.numberLimit = tool.nbToConstruct; // Limite le nombre de ressource à 99 par défaut
                t.number = 0;
            }
        }
        else
        {
            Tool res = new Tool();
            tool.copy(res);
            res.neededToTransport = true;
            res.name = tool.name;
            res.nbToTransport = 1;
            res.numberLimit = 10; // Limite le nombre de ressource à 99 par défaut
            res.number = 1;
            if (tool.nbToConstruct != -1)
            {
                res.nbToTransport = tool.nbToConstruct;
                res.numberLimit = tool.nbToConstruct; // Limite le nombre de ressource à 99 par défaut
                res.number = 0;
            }
            //Debug.Log(res.name);
            toolInventory.Add(res);
        }
    }
}
