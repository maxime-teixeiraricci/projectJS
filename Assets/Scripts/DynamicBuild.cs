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
    //bool isPlaced = false;

    Color originalColor;

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
        if (spawnedObj != null)
        {
           // if (!spawnedObj.GetComponent<Shelter>().isPlaced)
           // {
                updatePos(spawnedObj);
            //}
        }

        
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                validatePos(hit);
            }
        }
    }
    
    public void setPrefabShelter()
    {
        //valueTag = "Shelter";
        spawnedObj = Instantiate(shelter, hit.point, Quaternion.identity) as GameObject;
        originalColor = spawnedObj.GetComponent<MeshRenderer>().material.color;
        spawnedObj.GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0, 155);
        spawnedObj.GetComponent<Building>().goodPosition = true;
        //spawnedObj.GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0, 155);
        //isPlaced = false;
    }

    public void setPrefabCamp()
    {
        //valueTag = "Camp";
        spawnedObj = Instantiate(camp, hit.point, Quaternion.identity) as GameObject;
        originalColor = spawnedObj.GetComponent<MeshRenderer>().material.color;
        spawnedObj.GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0, 155);
        spawnedObj.GetComponent<Building>().goodPosition = true;
        //spawnedObj.GetComponent<MeshRenderer>().material.color = Color.red;

    }

    public void setPrefabHouse()
    {
        //valueTag = "House";
        spawnedObj = Instantiate(house, hit.point, Quaternion.identity) as GameObject;
        originalColor = spawnedObj.GetComponent<MeshRenderer>().material.color;
        spawnedObj.GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0, 155);
        spawnedObj.GetComponent<Building>().goodPosition = true;
        //spawnedObj.GetComponent<MeshRenderer>().material.color = Color.red;
        //isPlaced = false;
    }
    
    public void updatePos(GameObject obj)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            obj.transform.localPosition = new Vector3(hit.point.x, obj.transform.position.y, hit.point.z);
        }
    }
    
    
    

    public void validatePos(RaycastHit hit)
    {
        //Debug.Log("in it");
        //Instantiate(obj, hit.point, Quaternion.identity);
        if (spawnedObj.GetComponent<Building>().goodPosition)
        {
            spawnedObj.GetComponent<MeshRenderer>().material.color = originalColor;
            spawnedObj.GetComponent<Building>().isPlaced = true;
            spawnedObj = null;
        }
        
    }
}