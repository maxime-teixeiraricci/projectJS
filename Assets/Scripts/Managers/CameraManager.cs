using System.Collections;
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
        //Debug.Log("mouse = " + mousePosX);
        if (mousePosX < scrollDistance && transform.position.x > -25)
        {
            //transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime);
            transform.position += Vector3.right * -scrollSpeed * Time.deltaTime;
        }

        if (mousePosX >= Screen.width - scrollDistance && transform.position.x < 25)
        {
            transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
            //transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
        }

        if (mousePosY < scrollDistance && transform.position.z > -25)
        {
            transform.position += Vector3.forward * -scrollSpeed * Time.deltaTime;
            //transform.Translate(Vector3.forward * -scrollSpeed * Time.deltaTime);
        }

        if (mousePosY >= Screen.height - scrollDistance && transform.position.z < 25)
        {
            transform.position += Vector3.forward * scrollSpeed * Time.deltaTime;
            //transform.Translate(Vector3.forward * scrollSpeed * Time.deltaTime);
        }

        // Zoom
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (GetComponent<Camera>().transform.position.y > 6)
            {
                GetComponent<Camera>().transform.position = new Vector3(GetComponent<Camera>().transform.position.x, GetComponent<Camera>().transform.position.y - 0.5f, GetComponent<Camera>().transform.position.z);
            }
        }

        // Dezoom
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(GetComponent<Camera>().transform.position.y < 30)
            {
                GetComponent<Camera>().transform.position = new Vector3(GetComponent<Camera>().transform.position.x, GetComponent<Camera>().transform.position.y + 0.5f, GetComponent<Camera>().transform.position.z);
            }
        }
        /*
        if (Input.GetMouseButton(0))
        {
            // Souris va à gauche
            if (Input.GetAxis("Mouse X") < 0)
            {
                GetComponent<Camera>().transform.position = new Vector3(GetComponent<Camera>().transform.position.x + 0.2f, GetComponent<Camera>().transform.position.y, GetComponent<Camera>().transform.position.z);
            }

            if (Input.GetAxis("Mouse X") > 0)
            {

                GetComponent<Camera>().transform.position = new Vector3(GetComponent<Camera>().transform.position.x - 0.2f, GetComponent<Camera>().transform.position.y, GetComponent<Camera>().transform.position.z);
            }

            if(Input.GetAxis("Mouse Y") > 0)
            {
                GetComponent<Camera>().transform.position = new Vector3(GetComponent<Camera>().transform.position.x, GetComponent<Camera>().transform.position.y, GetComponent<Camera>().transform.position.z - 0.2f);
            }

            if (Input.GetAxis("Mouse Y") < 0)
            {
                GetComponent<Camera>().transform.position = new Vector3(GetComponent<Camera>().transform.position.x, GetComponent<Camera>().transform.position.y, GetComponent<Camera>().transform.position.z + 0.2f);
            }
            


        }*/

    }
}

