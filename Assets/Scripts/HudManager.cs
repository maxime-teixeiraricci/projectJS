using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

    public Ressource appleRessource;
    public Ressource woodRessource;

    public Image appleImage;
    public Image woodImage;

    // Use this for initialization
    void Start ()
    {
        appleImage.sprite = appleRessource.image;
        woodImage.sprite = woodRessource.image;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

}
