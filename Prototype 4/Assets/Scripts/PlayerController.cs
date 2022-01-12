using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5.0f;
    public bool hasPowerup;

    private GameObject focalPoint;
    public GameObject powerupIndicator;//güç göstergesi
    private float powerupStrength = 15.0f;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("Focal Point");
        //powerupIndicator = GameObject.FindGameObjectWithTag("Powerup Indicator");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Powerup")
        {
            hasPowerup = true;//güçlendi
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());//7 sn sonra false 
            powerupIndicator.gameObject.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);//offset

            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);//aradaki uzaklýðý bir andan arttýrsýn
        }
    }
    IEnumerator PowerupCountdownRoutine()//thread
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;//7 birim zaman sonra powerup false olacak
        powerupIndicator.gameObject.SetActive(false);
    }
}
