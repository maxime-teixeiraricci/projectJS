using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JaredBubblePopManager : MonoBehaviour {

    public GameObject bubbleText;
    public Text text;

    bool isActif;

    Building[] buildingToBuild;

    int oldNbrBld = 0;
    int numberBld = 0;

    void Start () {
        isActif = false;
        buildingToBuild = FindObjectsOfType<Building>();
        foreach (Building building in buildingToBuild)
        {
            if (building.isConstruct)
            {
                numberBld++;
            }
        }
    }
	
	
	void Update () {
        if (!isActif)
        {
            setMessage();
        }
	}

    public bool buildingBuilt()
    {
        oldNbrBld = numberBld;
        numberBld = 0;
        buildingToBuild = FindObjectsOfType<Building>();
        foreach(Building building in buildingToBuild)
        {
            if (building.isConstruct)
            {
                numberBld++;
            }
        }
        if(oldNbrBld < numberBld)
        {
            return true;
        }
        return false;
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

        float valueEnvironment = GameObject.Find("Environment").GetComponent<Slider>().value;

        if (valueEnvironment > 90)
        {
            messages.Add("L’environnement se porte merveilleusement bien, continuez comme ça !");
        }

        else if(valueEnvironment > 30 && valueEnvironment < 60)
        {
            messages.Add("L’environnement se dégrade petit à petit, soyez prudent.");
        }

        else if(valueEnvironment < 30)
        {
            messages.Add("L’environnement est dans un état critique, vous devriez en prendre soin !");
        }

        int nbrTools = int.Parse(GameObject.Find("ToolTotal").GetComponent<Text>().text);

        if(nbrTools > 40)
        {
            messages.Add("Notre stock d’outils déborde ! Peut-être devrions-nous suspendre la production ?");
        }
        
        bool newBat = buildingBuilt();
        if (newBat)
        {
            //messages.Add("Un bâtiment vient d'être construit !");
            popMessage("Un bâtiment vient d'être construit !");
        }
        if (!newBat)
        {
            if (messages.Count <= 0) return;
            int index = Random.Range(0, Mathf.Max(0, messages.Count));
            popMessage(messages[index]);
        }

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
