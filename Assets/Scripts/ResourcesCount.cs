using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesCount : MonoBehaviour {

    Text appleText;
    public Text woodText;
    /*
    GameObject canvasUI;
    Transform childApple;
    Transform childWood;
    Transform childAppleContainer;
    Transform childWoodContainer;
    */
    int apple;
    int wood = 0;

	// Use this for initialization
	void Start () {
        
        if(woodText.text != null)
        {
            wood = int.Parse(woodText.text);
        }

        //woodText = GameObject.Find("WoodTotal").GetComponent<Text>();
        //woodText.text = "2";
        
        /*
        canvasUI = GameObject.Find("Banner");
        childAppleContainer = canvasUI.transform.Find("AppleContainer");
        childApple = childAppleContainer.transform.Find("AppleTotal");
        appleText = childApple.GetComponent<Text>();

        childWoodContainer = canvasUI.transform.Find("WoodContainer");
        childWood = childWoodContainer.transform.Find("WoodTotal");  //le nom de votre objet UI Text*/
        //woodText = childWood.GetComponent<Text>();

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

