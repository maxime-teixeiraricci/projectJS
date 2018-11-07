using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressource : MonoBehaviour
{
    public RessourcePhase phase;
}

public enum RessourcePhase { FREE, OWNED, STOCKED};
