﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float mousePosX = Input.mousePosition.x;
        float mousePosY = Input.mousePosition.y;
        int scrollDistance = 5;
        float scrollSpeed = 15;
        Debug.Log("mouse = " + mousePosX);
        if (mousePosX < scrollDistance && transform.position.x > -25)
        {
            transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime);
           
        }

        if (mousePosX >= Screen.width - scrollDistance && transform.position.x < 25)
        {
            transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
        }

        if (mousePosY < scrollDistance && transform.position.y > 13)
        {
            transform.Translate(Vector3.up * -scrollSpeed * Time.deltaTime);
        }

        if (mousePosY >= Screen.height - scrollDistance && transform.position.y < 20)
        {
            transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<Camera>().fieldOfView--;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Camera>().fieldOfView++;
        }
    }
}

