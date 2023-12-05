using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject door;
    public MeshRenderer doorRenderer;
    void Start()
    {
        doorRenderer = GetComponent<MeshRenderer>();
    }

    
    void Update()
    {
        if (gameManager.enemies > 0)
        {
            //door.gameObject.SetActive(false);
            doorRenderer.enabled = false;
            
        }
        else
        {
            //door.gameObject.SetActive(true);
            doorRenderer.enabled = true;
        }
       
    }
}
