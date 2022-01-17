using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private Rigidbody boxRb;
    public bool isGround = false;
    public GameObject groundCube;
    [SerializeField] float speed;
    void Start()
    {
        boxRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        boxRb.AddForce(Vector3.right * horizontalInput * speed);
        boxRb.AddForce(Vector3.forward * verticalInput * speed);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}
