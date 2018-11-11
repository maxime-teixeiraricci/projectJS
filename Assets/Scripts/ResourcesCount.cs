using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesCount : MonoBehaviour {

    Text appleText;
    Text woodText;
    GameObject canvasUI;
    Transform childApple;
    Transform childWood;
    Transform childAppleContainer;
    Transform childWoodContainer;

    int apple;
    int wood;

	// Use this for initialization
	void Start () {

        canvasUI = GameObject.Find("Banner");
        childAppleContainer = canvasUI.transform.Find("AppleContainer");
        childApple = childAppleContainer.transform.Find("AppleTotal");
        appleText = childApple.GetComponent<Text>();

        childWoodContainer = canvasUI.transform.Find("WoodContainer");
        childWood = childWoodContainer.transform.Find("WoodTotal");  //le nom de votre objet UI Text
        woodText = childWood.GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Add(Ressource ressource)
    {
        if(ressource.nom == "Apple")
        {
            wood++;
            woodText.text = "" + wood;
        }
        //apple++;
        //appleText.text = "" + apple;
    }

    public void AddWood()
    {
        wood++;
        woodText.text = "" + wood;
    }

}

