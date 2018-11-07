using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum CitizenGroup { NONE,TRANSPORT, CONSTRUCT, PRODUCT};
public class CitizenNavigation : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public GameObject shirt;
    public CitizenGroup group;
    public List<GameObject> ressources;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (group)
        {
            case CitizenGroup.NONE:
                shirt.GetComponent<MeshRenderer>().material.color = Color.black;
                break;
            case CitizenGroup.TRANSPORT:
                shirt.GetComponent<MeshRenderer>().material.color = Color.blue;
                break;
            case CitizenGroup.CONSTRUCT:
                shirt.GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;
            case CitizenGroup.PRODUCT:
                shirt.GetComponent<MeshRenderer>().material.color = Color.green;
                break;
        }

        for (int i = 0; i < ressources.Count;i++)
        {
            if (i == 0) ressources[i].transform.position += (transform.position- ressources[i].transform.position)*0.15f;
            else ressources[i].transform.position += (ressources[i-1].transform.position - ressources[i].transform.position) * 0.15f;
        }
	}

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Batiment" && ressources.Count > 0 && ressources[0].GetComponent<Ressource>().phase == RessourcePhase.OWNED)
        {
            if (!other.GetComponent<Shelter>().full)
            {
                GameObject g = ressources[0];
                g.GetComponent<Ressource>().phase = RessourcePhase.STOCKED;
                other.GetComponent<Shelter>().Add(g);
                ressources.Remove(g);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ressource" && other.GetComponent<Ressource>().phase == RessourcePhase.FREE)
        {
            if (!ressources.Contains(other.gameObject) && ressources.Count < 5)
            {
                ressources.Add(other.gameObject);
                other.GetComponent<Ressource>().phase = RessourcePhase.OWNED;
                other.GetComponent<SphereCollider>().enabled = false;
                other.GetComponent<Rigidbody>().useGravity = false;
                other.tag = "RessourceOwned";
            }
        }
    }
}
