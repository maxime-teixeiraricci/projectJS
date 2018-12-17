using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesCount : MonoBehaviour {

    public static ResourcesCount singleton;

    Text appleText;
    public Text woodText;
    int apple;
    public int wood = 0;

	// Use this for initialization
	void Start () {
        if (!singleton) singleton = this;

        if(woodText.text != null)
        {
            wood = int.Parse(woodText.text);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(woodText.text != null)
        {
            wood = int.Parse(woodText.text);

        }
        
    }

    public void Add(Ressource ressource)
    {
        if(ressource.nom == "Wood")
        {
            wood++;
            woodText.text = (int.Parse(woodText.text) + 1).ToString();
        }
    }

    public void Remove(Ressource ressource)
    {
        if (ressource.nom == "Wood")
        {
            wood--;
            woodText.text = (int.Parse(woodText.text) - 1).ToString();
        }
    }


}

