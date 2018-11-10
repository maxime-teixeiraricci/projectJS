using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceContainer : MonoBehaviour
{
    public Ressource ressource;
    public int validityTime;
    public RessourcePhase phase;
    public RessourceType type;

    public void Start()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
