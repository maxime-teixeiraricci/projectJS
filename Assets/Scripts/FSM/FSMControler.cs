using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FSMControler : MonoBehaviour
{
    public FSMState currentState;

    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Citizen citizen;
    public GameObject target;
    public float farmTimer;
    public float buildTimer;
    public float craftTimer;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        citizen = GetComponent<Citizen>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentState.UpdateState(this); // On passe en argument le controler pour avoir une main sur l'entité qui subit la FSM
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = currentState.gizmoColor;
        Gizmos.DrawCube(transform.position + new Vector3(0, 1, 0), new Vector3(0.25f, 0.25f, 0.25f));
    }

    public void ChangeState(FSMState nextState)
    {
        if (nextState != null)
        {
            currentState = nextState;
        }
    }
}
