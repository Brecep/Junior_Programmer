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

    
    void LateUpdate()//kamera iþlemlerinde daha stabil çalýþýr
    {
        transform.position = player.transform.position + offset;
    }
}
