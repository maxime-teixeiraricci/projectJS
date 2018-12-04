using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "CitizenSetting/Citizen Settings")]
public class CitizenSetting : ScriptableObject
{
    public float distanceNearTarget = 1.0f;
    public int inventorySize = 5;
    public GroupIdleState[] idleGroupState;
}

[System.Serializable]
public struct GroupIdleState
{
    public Citizen.Group group;
    public FSMState idleState;
}