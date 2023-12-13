using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class AiMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public float dashVelocity;
    public GameManager gameManager;
    public bool dashable;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject playerDeathParticleSystem;
    


    private Rigidbody rb;

    private void Start()
    {
        StartCoroutine(dash(1));
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("player");
        gameManager = GameObject.Find("game manager").GetComponent<GameManager>();
        
        gameManager.enemies += 1;

        GameObject[] spawns = GameObject.FindGameObjectsWithTag("spawn");


        transform.position = spawns[Random.Range(0, spawns.Length)].transform.position;
    }
    IEnumerator dash(int time)
    {
        dashable = false;
        yield return new WaitForSeconds(time);
        dashable = true;
    }
    void Update()
    {
        if (gameManager.gameStarted)
        {
            agent.SetDestination(player.transform.position);

            if (dashable == true)
            {
                if (agent.velocity.magnitude == 0f)
                {
                    dashVelocity = 30;
                }
                transform.Translate(Vector3.forward * dashVelocity * Time.deltaTime);
                dashVelocity -= 30 * Time.deltaTime;
                if (dashVelocity < 0)
                {
                    dashVelocity = 0;
                }
            }
        }
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.isPlayerDead = true;
            Debug.Log("player dead");
            Instantiate(playerDeathParticleSystem, transform.position, transform.rotation);

        }
    }

       
}
