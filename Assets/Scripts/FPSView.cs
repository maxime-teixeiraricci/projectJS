using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSView : MonoBehaviour {

    public Camera camera;
    public bool fpsActivated = false;
    public GameObject fpsFeedBack;
    Vector3 defaultCamPos;
    Quaternion defaultCamRot;

    float speed = 2.0f;
    Quaternion targetRotation;
    Ray ray;
    RaycastHit hit;
    

    // Use this for initialization
    void Start () {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        fpsFeedBack = GameObject.Find("FeedbackFPS");
        defaultCamPos = camera.transform.position;
        defaultCamRot = camera.transform.rotation;
        
        hit = new RaycastHit();
    }
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (fpsActivated)
        {
            updateCamera();
        }
        resetPosition();
    }

    void LateUpdate()
    {
        
    }

    private void OnMouseDown()
    {
        camera.GetComponent<CameraManager>().enabled = false;
        updateCamera();
        fpsActivated = true;
        fpsFeedBack.GetComponent<Image>().enabled = true;
        fpsFeedBack.GetComponentInChildren<Text>().enabled = true;
    }

    public void updateCamera()
    {
        camera.transform.position = gameObject.transform.position;
        //camera.transform.rotation = gameObject.transform.rotation;
        camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, targetRotation, Time.deltaTime * speed);

        if (Physics.Raycast(ray, out hit, 1200))
        {
            Debug.DrawLine(ray.origin, hit.point);
            targetRotation = Quaternion.LookRotation(hit.point - camera.transform.position);
        }
    }

    public void resetPosition()
    {
        if(Input.GetKey(KeyCode.Escape) && fpsActivated)
        {
            fpsActivated = false;
            fpsFeedBack.GetComponent<Image>().enabled = false;
            fpsFeedBack.GetComponentInChildren<Text>().enabled = false;
            camera.GetComponent<CameraManager>().enabled = true;
            camera.transform.position = defaultCamPos;
            camera.transform.rotation = defaultCamRot;
        }
    }
    
}
