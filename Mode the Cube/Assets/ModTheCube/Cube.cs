using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private float randomPosition;
    private float randomRotate;
    public Material material;
    void Start()
    {
        //transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 3f;//vector3.one(1,1,1)


         material = Renderer.material;//meshrenderer component - CubeMaterial

        //material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
        //material.color = new Color(0, 1, 0, 1);//green

    }
    private float RandomPosition(float min, float max)
    {
        float randomPosition = Random.Range(min, max);
        return randomPosition;

    }
    private float RandomRotate(float min, float max)
    {
        float randomRotate = Random.Range(min, max) * Time.deltaTime;
        return randomRotate;

    }

    void FixedUpdate()
    {
        material.color = Color.Lerp(material.color, Color.black, 0.01f);
        transform.Rotate(RandomRotate(10, 20), RandomRotate(10, 20), RandomRotate(10, 20));//animation
        // transform.position = new Vector3(RandomPosition(0,5), RandomPosition(0, 5), RandomPosition(0, 5));
    }
}
