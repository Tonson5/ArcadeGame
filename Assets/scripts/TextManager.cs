using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    public GameManager GameManager;
    public TextMeshProUGUI restartGame;
    public TextMeshProUGUI score;
    public TextMeshProUGUI startGameText;
    public GameObject background;

    void Start()
    {
        
    }



    void Update()
    {
        if (GameManager.isPlayerDead)
        {
            restartGame.gameObject.SetActive(true); 
        }

        if (GameManager.startGame)
        {
             startGameText.gameObject.SetActive(true);
            background.SetActive(true);
        }

        if (!GameManager.startGame)
        {
            startGameText.gameObject.SetActive(false);
            background.SetActive(false);
        }

        score.text = "Score: " + GameManager.score;
    }
}
