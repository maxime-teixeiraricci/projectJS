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


    public void Update()
    {
        textTitle.text = evenement.titre;
        textDescription.text = evenement.description;
        for (int i = 0; i < textResponses.Length; i ++)
        {
            textResponses[i].text = evenement.reponses[i].text;
        }
    }
}
