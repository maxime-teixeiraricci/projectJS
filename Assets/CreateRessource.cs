using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRessource : MonoBehaviour
{
    public GameObject ressource1;
    public GameObject ressource2;
    public int numberRessource = 200;
    public float t;

	
	
	// Update is called once per frame
	void Update ()
    {
        t += Time.deltaTime;
		if (t > 1f)
        {
            for (int i = 0; i < ((Random.Range(0, 1f) < 0.9f) ? 1 : 3); i++)
            {
                Vector3 movement = Vector3.up + new Vector3(Random.Range(-1, 1f), 0, Random.Range(-1, 1f));
                GameObject r = Instantiate((Random.Range(0, 1f) < 0.7f) ? ressource1 : ressource2);
                r.transform.position = this.transform.position + Vector3.up;
                r.GetComponent<Rigidbody>().AddForce(movement.normalized * 200);
                t = 0;
                numberRessource--;
            }
        }

        if (numberRessource <=0)
        {
            Destroy(gameObject);
        }
	}
}
