using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI restartGame;
    public TextMeshProUGUI score;
    public TextMeshProUGUI startGameText;
    public GameObject background;
    public GameObject noDash;
    

    void Start()
    {
        
    }



    void Update()
    {
        if (gameManager.isPlayerDead)
        {
            restartGame.gameObject.SetActive(true); 
        }

        if (gameManager.startGame)
        {
             startGameText.gameObject.SetActive(true);
            background.SetActive(true);
        }

        if (!gameManager.startGame)
        {
            startGameText.gameObject.SetActive(false);
            background.SetActive(false);
        }
        if (gameManager.playerDash)
        {
            noDash.gameObject.SetActive(false);
            
        }
        else
        {
            noDash.gameObject.SetActive(true);
        }


        score.text = "Score: " + gameManager.score;
    }
}
