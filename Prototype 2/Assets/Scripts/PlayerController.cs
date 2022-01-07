using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float verticalInput;
    public float horizontalInput;
    public float speed;
    private float xRange = 10;
    private float zRangeMax = 5;
    private float zRangeMin = 0;

    public GameObject projectilePrefab;

    public static double score;
    public static double lives;


    void Start()
    {
        score = 0;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");//Bonus
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);//Bonus

        if (transform.position.z > zRangeMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeMax);
        }
        if (transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeMin);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }


}
