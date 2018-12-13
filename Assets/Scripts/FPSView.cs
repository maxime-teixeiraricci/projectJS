using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSView : MonoBehaviour {

    public Camera camera;
    public bool fpsActivated = false;
    Vector3 defaultCamPos;
    Quaternion defaultCamRot;

    float speed = 2.0f;
    Quaternion targetRotation;
    Ray ray;
    RaycastHit hit;
    

    // Use this for initialization
    void Start () {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
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
            camera.GetComponent<CameraManager>().enabled = true;
            camera.transform.position = defaultCamPos;
            camera.transform.rotation = defaultCamRot;
        }
    }
    
}
