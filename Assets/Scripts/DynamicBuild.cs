using UnityEngine;

using System.Collections;

public class DynamicBuild : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;
    public GameObject shelter;
    public GameObject camp;
    public GameObject house;

    GameObject spawnedObj;
    bool isPlaced = false;

    //string valueTag;
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
        if(spawnedObj != null && !isPlaced)
        {
            updatePos(spawnedObj);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                
                //if (hit.collider.gameObject.tag == "Soil")
                //{
                    //Debug.Log("hello?");
                    validatePos(spawnedObj, hit);
                    /*
                    if (valueTag == "Shelter")
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
                    }*/
                    
                //}
            }
        }
    }
    
    public void setPrefabShelter()
    {
        //valueTag = "Shelter";
        spawnedObj = Instantiate(shelter, hit.point, Quaternion.identity) as GameObject;
        isPlaced = false;
    }

    public void setPrefabCamp()
    {
        //valueTag = "Camp";
        spawnedObj = Instantiate(camp, hit.point, Quaternion.identity) as GameObject;
        isPlaced = false;
    }

    public void setPrefabHouse()
    {
        //valueTag = "House";
        spawnedObj = Instantiate(house, hit.point, Quaternion.identity) as GameObject;
        isPlaced = false;
    }
    
    public void updatePos(GameObject obj)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            obj.transform.localPosition = new Vector3(hit.point.x, obj.transform.position.y, hit.point.z);
        }
    }

    public void validatePos(GameObject obj, RaycastHit hit)
    {
        Debug.Log("in it");
        Instantiate(obj, hit.point, Quaternion.identity);
        isPlaced = true;
    }
}