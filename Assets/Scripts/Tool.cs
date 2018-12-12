using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolType { Arc, Flèche, Hache, Secateur};

/* 
 * Il faut mettre les enums en dehors de la classe pour y avoir acces en dehors de la classe. Notamment quand on aura
 * A faire des test dessus.
*/
[System.Serializable]
public class Tool
{
    public int index;
    public string name;
    public float timeToCraft;

    public bool neededToConstruct;
    public int nbToConstruct;

    public bool neededToTransport;
    public int nbToTransport;

    public int number;
    public int numberLimit;

    public Ressource ressourceNeeded;
    public int numberRessourcesNeeded;

    public void copy(Tool t)
    {
        t.name = name;
        t.number = number;
        t.numberLimit = numberLimit;
        t.nbToConstruct = nbToConstruct;
        t.nbToTransport = nbToTransport;
        t.neededToTransport = neededToTransport;
        t.neededToConstruct = neededToConstruct;
    }
}
