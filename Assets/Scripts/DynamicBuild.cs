using UnityEngine;

using System.Collections;

public class DynamicBuild : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;
    public GameObject shelter;
    public GameObject camp;
    public GameObject house;

    string valueTag;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    /*
    void Update()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {

            if (Input.GetKey(KeyCode.Mouse0) && built == false)
            {
                GameObject obj = Instantiate(prefab, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
                mixedUp();

            }

        }
    }
    */
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && valueTag != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Soil")
                {
                    if(valueTag == "Shelter")
                    {
                        Instantiate(shelter, hit.point, Quaternion.identity);
                    }
                    else if(valueTag == "Camp")
                    {
                        Instantiate(camp, hit.point, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(house, hit.point, Quaternion.identity);
                    }
                    
                }
            }
        }
    }

    public void setPrefabShelter()
    {
        valueTag = "Shelter";
    }

    public void setPrefabCamp()
    {
        valueTag = "Camp";
    }

    public void setPrefabHouse()
    {
        valueTag = "House";
    }
}