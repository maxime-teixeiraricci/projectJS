using UnityEngine;
using System.Collections;

public class PanCam : MonoBehaviour
{
    public GameObject player;

    // Use this for initialization

    // Update is called once per frame 
    void Update () {
        
        //check that player exists and then proceed. otherwise we get an error when player dies 
        if (player) {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -2.53f);
        }
    }
}


