using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject propeller;
    public float animationSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        propeller.transform.Rotate(Vector3.back * Time.deltaTime * animationSpeed);
        
        // propeller.transform.rotation = Quaternion.EulerAngles(Vector3.forward * Time.deltaTime * 5);
        //propeller.transform.eulerAngles = Vector3.back * Time.deltaTime * animationSpeed;
    }
}
