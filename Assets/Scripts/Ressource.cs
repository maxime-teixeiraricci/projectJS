using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RessourceType { Poisson, Viande, Fruit, Herb, Eau, EauSale, Pierre, Fer, Or, Bois };
public enum RessourcePhase { FREE, OWNED, STOCKED };
/* 
 * Il faut mettre les enums en dehors de la classe pour y avoir acces en dehors de la classe. Nottament quand on aura
 * A faire des test dessus.
*/
public class Ressource : MonoBehaviour
{
    public RessourcePhase phase;
    public RessourceType type;

    string nom;
    int tempsDeValidite;
    Sprite image;

	void Start () {
		
	}
	
	void Update () {
		
	}
}
