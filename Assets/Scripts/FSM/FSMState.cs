using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State")]
public class FSMState : ScriptableObject
{

    public FSMAction[] actions;
    public FSMTransition[] transitions;

    // DEBUG
    public Color gizmoColor = Color.grey; // Couleur par défaut;
    //

    public void UpdateState(FSMControler controler)
    {
        DoActions(controler);
        TakeDecision(controler);
    }

    public void DoActions(FSMControler controler)
    {
        foreach (FSMAction action in actions){ action.Act(controler); }
    }

    public void TakeDecision(FSMControler controler)
    {
        foreach (FSMTransition transition in transitions)
        {
            if (transition.Check(controler))
            {
                controler.ChangeState(transition.nextState);
            }
        }
    }


}
