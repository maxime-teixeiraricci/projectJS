using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Evenements/Evenement Response")]
public class EvenementReponse : ScriptableObject
{
    public string text;
    public Gauge[] changeGauge;
}
