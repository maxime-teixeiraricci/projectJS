using UnityEngine;

using System.Collections;
using UnityEngine.AI;

public class DynamicBuild : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    public GameObject camp;
    public GameObject house;

    GameObject spawnedObj;

    Color originalColor;

    // Use this for initialization
    void Start()
    {
    }

    void Update()
    {
        if (spawnedObj != null)
        {
                updatePos(spawnedObj);
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

        if (Input.GetMouseButton(1))
        {
            Destroy(spawnedObj);
        }
    }

    public void setPrefabCamp()
    {
        spawnedObj = Instantiate(camp, new Vector3(hit.point.x, 1, hit.point.z), Quaternion.identity) as GameObject;
        originalColor = spawnedObj.GetComponent<MeshRenderer>().material.color;
        spawnedObj.GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0, 155);
        spawnedObj.GetComponent<Building>().goodPosition = true;
        spawnedObj.GetComponent<NavMeshObstacle>().enabled = false;
    }

    public void setPrefabHouse()
    {
        spawnedObj = Instantiate(house, new Vector3(hit.point.x, 1, hit.point.z), Quaternion.identity) as GameObject;
        originalColor = spawnedObj.GetComponent<MeshRenderer>().material.color;
        spawnedObj.GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0, 155);
        spawnedObj.GetComponent<Building>().goodPosition = true;
        spawnedObj.GetComponent<NavMeshObstacle>().enabled = false;
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
        if (spawnedObj.GetComponent<Building>().goodPosition)
        {
            spawnedObj.GetComponent<MeshRenderer>().material.color = originalColor;
            spawnedObj.GetComponent<Building>().isPlaced = true;
            spawnedObj.GetComponent<NavMeshObstacle>().enabled = true;
            spawnedObj = null;
        }
        
    }
}