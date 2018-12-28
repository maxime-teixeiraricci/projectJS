using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenSoundEventManager : MonoBehaviour {
    //FMOD Studio variables
    //The FMOD Studio Event path.
    //This script is designed for use with an event that has a game parameter for each of the surface variables, but it will still compile and run if they are not present.
    [FMODUnity.EventRef]
    public string m_EventPath;

    public float m_Wood;
    public float m_Water;
    public float m_Dirt;
    public float m_Sand;

    void Start()
    {
    }

    void Update()
    {
            PlaySound();
    }

    void PlaySound()
    {
        //Defaults
        m_Water = 0.0f;
        m_Dirt = 0.0f;
        m_Sand = 0.0f;
        m_Wood = 0.0f;


        if (m_EventPath != null)
        {
                FMOD.Studio.EventInstance e = FMODUnity.RuntimeManager.CreateInstance(m_EventPath);
                e.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));


   

                SetParameter(e, "Wood", m_Wood);
                SetParameter(e, "Dirt", m_Dirt);
                SetParameter(e, "Sand", m_Sand);
                SetParameter(e, "Water", m_Water);

                e.start();
                e.release();//Release each event instance immediately, there are fire and forget, one-shot instances. 
        }
    }

    void SetParameter(FMOD.Studio.EventInstance e, string name, float value)
    {
        FMOD.Studio.ParameterInstance parameter;
        e.getParameter(name, out parameter);
        if (parameter.Equals(null))
        {
            return;
        }
        parameter.setValue(value);
    }
}
