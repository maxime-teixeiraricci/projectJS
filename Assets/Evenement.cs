using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Evenements/Evenement")]
public class Evenement : ScriptableObject
{
    public string titre;
    public string description;
    public EvenementReponse[] reponses;

}
