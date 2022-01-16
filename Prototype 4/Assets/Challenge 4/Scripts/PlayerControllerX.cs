using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500;
    private GameObject focalPoint;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public ParticleSystem particleSystem;
    public int powerUpDuration = 5;

    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
       //particleSystem = GameObject.FindGameObjectWithTag("Smoke_Particle").name;
    }

    private float skillSpeed;
    private float boostedSpeed = 2000;//bonus
    private bool boostedTime = false;//bonus

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);

        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);

        if (Input.GetKey(KeyCode.Space) && !boostedTime)
        {
            playerRb.AddForce(focalPoint.transform.forward * verticalInput * boostedSpeed * Time.deltaTime);
            particleSystem.Play();
            boostedTime = true;
        }
        else
        {
            boostedTime = false;
            particleSystem.Stop();
        }


        /*
        if (Input.GetKeyDown(KeyCode.Space) && !boostedTime)//bonus
        {
            playerRb.AddForce(focalPoint.transform.position * boostedSpeed, ForceMode.Impulse);//bonus
            boostedTime = true;
            particleSystem.Play();
            StartCoroutine(BoostCoolDown());
        }
        */
    }
    /*
    private void StartCoroutine(IEnumerable enumerable)
    {
        throw new NotImplementedException();
    }

    IEnumerable BoostCoolDown()
    {
        yield return new WaitForSeconds(3);
        boostedTime = false;
        particleSystem.Stop();
    }*/

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);

    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position);

            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }


        }

    }



}
