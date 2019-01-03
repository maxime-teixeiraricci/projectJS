using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EvenementManager : MonoBehaviour
{
    public Evenement evenement;

    [Header("HUD")]
    public Text textTitle;
    public Text textDescription;
    public Text[] textResponses;

    public GameObject errorMessage;


    public void Update()
    {
        Time.timeScale = 0;
        textTitle.text = evenement.titre;
        textDescription.text = evenement.description;
        for (int i = 0; i < textResponses.Length; i ++)
        {
            textResponses[i].text = evenement.reponses[i].text;
        }
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    public void ActivateResponse(int i)
    {
        if(ResourcesCount.singleton.wood < 10 && evenement.reponses[i].value == -10)
        {
            gameObject.SetActive(false);
            errorMessage.SetActive(true);
            return;
        }
        FactorsManager.singleton.AddRessource(evenement.reponses[i].changeGauge[0].value);
        ResourcesCount.singleton.boostTrees(evenement.reponses[i].value);
        gameObject.SetActive(false);
    }

    public void recycleTools()
    {
        GameObject toolsCount = GameObject.Find("ToolTotal");
        GameObject woodCount = GameObject.Find("WoodTotal");

        FactorsManager.singleton.AddRessource(25);

        toolsCount.GetComponent<Text>().text = (int.Parse(toolsCount.GetComponent<Text>().text) - 5).ToString();
        woodCount.GetComponent<Text>().text = (int.Parse(woodCount.GetComponent<Text>().text) + 25).ToString();

        gameObject.SetActive(false);
    }
    
    public void hideWindow()
    {
        gameObject.SetActive(false);
    }
}
