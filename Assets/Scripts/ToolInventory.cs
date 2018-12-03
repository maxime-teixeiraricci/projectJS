﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolInventory : MonoBehaviour {

    [HideInInspector] public Dictionary<Tool, int> toolStock = new Dictionary<Tool, int>();

    public List<Tool> toolInventory;

    // L'outil qui sera produit
    public Tool activeTool;

    public int nbrTools = 0;

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
        activeTool = toolInventory[0];
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
            return true;
        }
        
        return false;
    }
}