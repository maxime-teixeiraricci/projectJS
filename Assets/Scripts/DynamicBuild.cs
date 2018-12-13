using UnityEngine;

using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;

public class DynamicBuild : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    public GameObject camp;
    public GameObject house;
    public GameObject statue;

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

        
        if (Input.GetMouseButtonDown(0) && spawnedObj != null)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                validatePos(hit);
            }
        }

        if (Input.GetMouseButton(1) && spawnedObj != null)
        {
            Destroy(spawnedObj);
        }
    }

    public void setPrefabCamp()
    {
        spawnedObj = Instantiate(camp, new Vector3(hit.point.x, 1, hit.point.z), Quaternion.identity) as GameObject;
        originalColor = spawnedObj.GetComponent<Building>().mesh.material.color;
        spawnedObj.GetComponent<Building>().mesh.material.color = new Color(0, 255, 0, 155);
        spawnedObj.GetComponent<Building>().goodPosition = true;
        spawnedObj.GetComponent<NavMeshObstacle>().enabled = false;
        spawnedObj.GetComponent<ResourcesCount>().woodText = GameObject.Find("WoodTotal").GetComponent<Text>();
        spawnedObj.GetComponent<ToolInventory>().wood = GameObject.Find("WoodTotal").GetComponent<Text>();
        spawnedObj.GetComponent<ToolInventory>().toolCount = GameObject.Find("ToolTotal").GetComponent<Text>();
    }

    public void setPrefabHouse()
    {
        spawnedObj = Instantiate(house, new Vector3(hit.point.x, 1, hit.point.z), Quaternion.identity) as GameObject;
        originalColor = spawnedObj.GetComponent<Building>().mesh.material.color;
        spawnedObj.GetComponent<Building>().mesh.material.color = new Color(0, 255, 0, 155);
        spawnedObj.GetComponent<Building>().goodPosition = true;
        spawnedObj.GetComponent<NavMeshObstacle>().enabled = false;
        spawnedObj.GetComponent<ResourcesCount>().woodText = GameObject.Find("WoodTotal").GetComponent<Text>();
        spawnedObj.GetComponent<ToolInventory>().wood = GameObject.Find("WoodTotal").GetComponent<Text>();
        spawnedObj.GetComponent<ToolInventory>().toolCount = GameObject.Find("ToolTotal").GetComponent<Text>();
    }

    public void setPrefabStatue()
    {
        spawnedObj = Instantiate(statue, new Vector3(hit.point.x, 1, hit.point.z), Quaternion.identity) as GameObject;
        originalColor = spawnedObj.GetComponent<Building>().mesh.material.color;
        spawnedObj.GetComponent<Building>().mesh.material.color = new Color(0, 255, 0, 155);
        spawnedObj.GetComponent<Building>().goodPosition = true;
        spawnedObj.GetComponent<NavMeshObstacle>().enabled = false;
        spawnedObj.GetComponent<ResourcesCount>().woodText = GameObject.Find("WoodTotal").GetComponent<Text>();
        spawnedObj.GetComponent<ToolInventory>().wood = GameObject.Find("WoodTotal").GetComponent<Text>();
        spawnedObj.GetComponent<ToolInventory>().toolCount = GameObject.Find("ToolTotal").GetComponent<Text>();
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
            spawnedObj.GetComponent<Building>().mesh.material.color = originalColor;
            spawnedObj.GetComponent<Building>().isPlaced = true;
            spawnedObj.GetComponent<NavMeshObstacle>().enabled = true;
            spawnedObj = null;
        }
        
    }
}