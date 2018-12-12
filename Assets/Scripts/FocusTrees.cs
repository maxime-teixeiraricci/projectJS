using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusTrees : MonoBehaviour {

    List<Citizen> citizen;
    public MeshRenderer mesh;

    Color originalColor;


    // Use this for initialization
    void Start ()
    {
        citizen = GameObject.Find("Dispatcher").GetComponent<DispatcherManager>().collectCitizens;
        originalColor = mesh.material.color;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    private void OnMouseDown()
    {
        
        foreach (Citizen cit in citizen)
        {
            cit.GetComponent<FSMControler>().manualTarget = gameObject;
        }
        StartCoroutine(colorChange());

    }

    IEnumerator colorChange()
    {
        mesh.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        mesh.material.color = originalColor;
    }
}
