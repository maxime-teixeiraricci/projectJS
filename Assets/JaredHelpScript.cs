using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JaredHelpScript : MonoBehaviour
{
    public Camera cam;
    public Color normal;
    public Color over;
    public GameObject text;

    public void Start()
    {
        normal = GetComponent<MeshRenderer>().material.color;
        over = Color.white;
    }

    public void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        GetComponent<MeshRenderer>().material.color = normal;
        //text.SetActive(false);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject == gameObject )
            {
                GetComponent<MeshRenderer>().material.color = over;
                //text.SetActive(true);
            }
        }
    }

}
