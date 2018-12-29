using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JaredBubblePopManager : MonoBehaviour {

    public GameObject bubbleText;
    public Text text;

    bool isActif;

    Building[] buildingToBuild;

    int oldNbrBld;
    int numberBld = 0;

    void Start () {
        isActif = false;
	}
	
	
	void Update () {
        if (!isActif)
        {
            setMessage();
        }
	}

    // *************************************  WARNING   *************************************

    // J'essaie de comparer la liste des buildings à construire du tick précédent à celle du tick courant, et je comapre leur taille, voir si un batiment a été craft entre deux ticks
    // J'vois pas comment faire sinon c'est la grosse merde, si jamais t'as une idée x)
    public bool buildingBuilt()
    {
        oldNbrBld = numberBld;
        buildingToBuild = FindObjectsOfType<Building>();
        numberBld = buildingToBuild.Length;
        if(oldNbrBld < numberBld)
        {
            return true;
        }
        return false;
    }

    // *************************************  END WARNING   *************************************

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

        // *************************************  WARNING   *************************************
        // Experimental de ouf du coup !
        if (buildingBuilt())
        {
            messages.Add("Un bâtiment vient d'être construit !");
        }
        // ************************************* END WARNING   *************************************

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
