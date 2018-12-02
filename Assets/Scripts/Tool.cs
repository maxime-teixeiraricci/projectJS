using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolType { Arc, Flèche, Hache, Secateur};

/* 
 * Il faut mettre les enums en dehors de la classe pour y avoir acces en dehors de la classe. Notamment quand on aura
 * A faire des test dessus.
*/
[CreateAssetMenu(menuName = "Ressource/Create Tool")]
public class Tool : ScriptableObject
{
    public string nom;
    public float timeToCraft;

    public Ressource ressourceNeeded;
    public int numberRessourcesNeeded;
}
