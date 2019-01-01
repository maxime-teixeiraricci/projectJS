using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JaredBubblePopManager : MonoBehaviour {

    public GameObject bubbleText;
    public Text text;

    bool isActif;

    Building[] buildingToBuild;

    int oldNbrHouse = 0;
    int oldNbrCamp = 0;
    int oldNbrStatue = 0;

    void Start () {
        isActif = false;
        buildingToBuild = FindObjectsOfType<Building>();
        foreach (Building building in buildingToBuild)
        {
            if (building.isConstruct && building.tag == "House")
            {
                oldNbrHouse++;
            }
            if (building.isConstruct && building.tag == "Camp")
            {
                oldNbrCamp++;
            }
            if (building.isConstruct && building.tag == "Statue")
            {
                oldNbrStatue++;
            }
        }
    }
	
	
	void Update () {
        if (!isActif)
        {
            setMessage();
        }
	}

    public int buildingBuilt()
    {
        int numberHouse = 0;
        int numberCamp = 0;
        int numberStatue = 0;
        buildingToBuild = FindObjectsOfType<Building>();
        foreach(Building building in buildingToBuild)
        {
            if (building.isConstruct && building.tag == "House")
            {
                numberHouse++;
            }
            if (building.isConstruct && building.tag == "Camp")
            {
                numberCamp++;
            }
            if (building.isConstruct && building.tag == "Statue")
            {
                numberStatue++;
            }
        }
        if(oldNbrStatue < numberStatue)
        {
            return 1;
        }
        if (oldNbrCamp < numberCamp)
        {
            return 2;
        }
        if (oldNbrHouse < numberHouse)
        {
            return 3;
        }
        return -1;
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
        
        int newBat = buildingBuilt();
        if (newBat != -1)
        {
            if (newBat == 1)
            {
                oldNbrStatue++;
                //messages.Add("Un bâtiment vient d'être construit !");
                popMessage("Une statue vient d'être construite. Félicitations! Vous vous rapprochez de l'objectif!");
                return;
            }
            if (newBat == 2)
            {
                oldNbrCamp++;
                //messages.Add("Un bâtiment vient d'être construit !");
                popMessage("Un camp vient d'être construit. Vous pouvez y assigner deux récolteurs supplémentaires!");
                return;
            }
            if (newBat == 3)
            {
                oldNbrHouse++;
                //messages.Add("Un bâtiment vient d'être construit !");
                popMessage("Une maison vient d'être construite. Deux nouveaux habitants ont rejoint votre société, bravo!");
                return;
            }
        }
        if (newBat == -1)
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
        yield return new WaitForSeconds(5.0f);
        bubbleText.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        isActif = false;
    }
}
