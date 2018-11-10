using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FSMTransition
{
    /* Transition d'une FSM:
     * Passe à l'état donné si toutes les FSMDecision sont VRAIS
     */
    public FSMDecision[] decisions;
    public FSMState nextState;

    public bool Check(FSMControler controler)
    {
        foreach (FSMDecision decision in decisions)
        {
            // Une seule decision FAUSSE renvoie FAUX;
            if (decision.Decide(controler) == false) return false; 
        }
        // Si toutes les décisions sont passées -> VRAI
        return true;
    }
}
