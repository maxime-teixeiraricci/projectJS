using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JaredBubblePopManager : MonoBehaviour {

    public GameObject bubbleText;
    public Text text;

    bool isActif;

    void Start () {
        isActif = false;
	}
	
	
	void Update () {
        if (!isActif)
        {
            setMessage();
        }
	}

    public void setMessage()
    {
        List<string> messages = new List<string>();
        NaturalRessource[] trees = GameObject.FindObjectsOfType<NaturalRessource>();

        foreach (NaturalRessource tree in trees)
        {
            if (tree.numberRessource / tree.maxRessource * 100 < 15)
            {
                messages.Add("Attention, un arbre va bientôt s’effondrer !");

            }
        }

        if(GameObject.Find("Environment").GetComponent<Slider>().value > 60)
        {
            messages.Add("L’environnement se porte merveilleusement bien, continuez comme ça !");
        }
        System.Random rand = new System.Random();
        int index = rand.Next(0, messages.Count);
        popMessage(messages[index]);
        Debug.Log(index);

    }

    public void popMessage(string message)
    {
        StartCoroutine(showMessage(message));
    }

    IEnumerator showMessage(string message)
    {
        text.text = message;
        bubbleText.SetActive(true);
        isActif = true;
        yield return new WaitForSeconds(1.0f);
        bubbleText.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        isActif = false;
    }
}
