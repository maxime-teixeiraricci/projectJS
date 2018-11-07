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

    int apple;
    int wood;

	// Use this for initialization
	void Start () {
        canvasUI = GameObject.Find("Canvas");
        childApple = canvasUI.transform.Find("AppleCount");  //le nom de votre objet UI Text
        appleText = childApple.GetComponent<Text>();

        childWood = canvasUI.transform.Find("WoodCount");  //le nom de votre objet UI Text
        woodText = childWood.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddApple()
    {
        apple++;
        appleText.text = "" + apple;
    }

    public void AddWood()
    {
        wood++;
        woodText.text = "" + wood;
    }

}

