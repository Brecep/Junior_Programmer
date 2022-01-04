using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    private float horizontalInput;
    private float forwardInput;

    void Start()
    {

    }


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);//z ekseninde hareket verdik
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);//y ekseninde rotation

    }
}
