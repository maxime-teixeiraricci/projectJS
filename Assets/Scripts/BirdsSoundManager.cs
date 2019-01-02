using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsSoundManager : MonoBehaviour {

    public DayNightController timeControler;
    public FMODUnity.StudioEventEmitter soundBirds;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timeControler.day)
        {
            FMOD.Studio.ParameterInstance parameter;
            soundBirds.EventInstance.getParameter("Day", out parameter);
            if (!parameter.Equals(null))
            {
                parameter.setValue(1.0f);
            }
            soundBirds.EventInstance.getParameter("Night", out parameter);
            if (!parameter.Equals(null))
            {
                parameter.setValue(0.0f);
            }
        }

        else
        {
            FMOD.Studio.ParameterInstance parameter;
            soundBirds.EventInstance.getParameter("Night", out parameter);
            if (!parameter.Equals(null))
            {
                parameter.setValue(1.0f);
            }
            soundBirds.EventInstance.getParameter("Day", out parameter);
            if (!parameter.Equals(null))
            {
                parameter.setValue(0.0f);
            }
        }
    }
}
