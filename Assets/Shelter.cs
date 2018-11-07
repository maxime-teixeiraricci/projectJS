using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter : MonoBehaviour
{
    public List<GameObject> ressources;
    public float dX;
    public float dY;
    public int nX;
    public int nY;
    public bool full;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    for (int i = 0; i < ressources.Count; i++)
        {
            ressources[i].transform.position = new Vector3((i%nX) * dX/(nX-1) - dX*0.5f, 0.5f, (i / nX) * dY / (nY-1) - dY * 0.5f) + transform.position;
            full = (ressources.Count == nX * nY);
        }
	}

    public void Add(GameObject ressource)
    {
        if (ressources.Count < nX*nY && !ressources.Contains(ressource))
        {
            ressources.Add(ressource);
            
        }
    }
}
