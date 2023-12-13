using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = (new Vector3 (player.transform.position.x / 10,transform.position.y,player.transform.position.z / 10));
    }
}
