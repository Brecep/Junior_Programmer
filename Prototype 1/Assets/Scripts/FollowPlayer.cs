using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -7);
    void Start()
    {
        
    }

    
    void LateUpdate()//kamera i�lemlerinde daha stabil �al���r
    {
        transform.position = player.transform.position + offset;
    }
}
