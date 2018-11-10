using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RessourceType { Poisson, Viande, Fruit, Herb, Eau, EauSale, Pierre, Fer, Or, Bois };
public enum RessourcePhase { FREE, OWNED, STOCKED };
/* 
 * Il faut mettre les enums en dehors de la classe pour y avoir acces en dehors de la classe. Nottament quand on aura
 * A faire des test dessus.
*/
[CreateAssetMenu(menuName = "Ressource/Create Ressource")]
public class Ressource : ScriptableObject
{
    public string nom;
    public int tempsDeValidite;
    public Sprite image;
}
