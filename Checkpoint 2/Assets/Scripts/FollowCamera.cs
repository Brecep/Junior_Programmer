using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Vector3 offset;
    [SerializeField] GameObject box;
    void Start()
    {
        offset = transform.position - box.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = box.transform.position + offset;
    }
}
