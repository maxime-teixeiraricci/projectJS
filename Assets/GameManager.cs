using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Gauge[] gauges;

}

[System.Serializable]
public class Gauge
{
    public string name;
    public float value;
}