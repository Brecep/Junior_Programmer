using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float turnSpeed;
    [SerializeField] private float horsePower = 0;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }


    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (IsOnGround())//zeminde olduðu sürece güç uygulasýn
        {
            // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);//z ekseninde hareket verdik
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);//y ekseninde rotation

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f);//kph cinsinden gerçek anlamda
            speedometerText.SetText("Speed : " + speed + " mph");

            rpm = Mathf.Round((speed % 30) * 60);
            rpmText.SetText("Rpm : " + rpm);
        }
    }
    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)//çarpýþmayý kontrol eder
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)//tekerlek sayýsý 
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
