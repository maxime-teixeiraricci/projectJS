using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public float time = 500;
    public float t = 0;
    public GameObject _event;
    public GameObject eventTools;

    GameObject toolNbr;

	// Use this for initialization
	void Start () {
        toolNbr = GameObject.Find("ToolTotal");
	}
	
	// Update is called once per frame
	void Update ()
    {
        t -= Time.deltaTime;
        t = Mathf.Max(0, t);
        //print("Factor : " + FactorsManager.singleton.slider.value); 

        if (t <= 0 && FactorsManager.singleton.slider.value <= 40.0f)
        {
            _event.SetActive(true);
            t = time;
        }

        if(t <= 0 && int.Parse(toolNbr.GetComponent<Text>().text) > 10)
        {
            eventTools.SetActive(true);
            t = time;
        }
	}
}
