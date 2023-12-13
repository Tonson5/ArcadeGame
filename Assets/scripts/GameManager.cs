using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPlayerDead = false;
    public int score = 0;
    public bool startGame;
    public bool gameStarted;
    public int enemies;
    public int difficulty = 1;
    public GameObject enemy;
    public bool playerDash;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        startGame = true;
    }


    void Update()
    {
        if (isPlayerDead && Input.GetButtonDown("start"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (startGame && Input.GetButtonDown("start"))
        {
            gameStarted = true;
            startGame=false;
            
        }
    }
    public void NewRoom()
    {
        difficulty += 1;
        for(int i = 0; i < difficulty; i++) 
        {
            Instantiate(enemy, transform.position, transform.rotation);
        }
    }
}
