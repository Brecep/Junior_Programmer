using System.Collections;
using UnityEngine;
using System.Collections.Generic;


public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem sparksParticles;

    private List<string> textToDisplay;

    // private float rotatingSpeed;
    private float timeToNextText;

    private int CurrentText;

    // Start is called before the first frame update
    void Start()
    {
        textToDisplay = new List<string>();
        Text = GetComponent<TextMesh>();

        timeToNextText = 0.0f;
        CurrentText = 0;

        // rotatingSpeed = 1.0f;

        textToDisplay.Add("Congratulation");
        textToDisplay.Add("All Errors Fixed");

        Text.text = textToDisplay[0];

        sparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timeToNextText += Time.deltaTime;

        if (timeToNextText > 1.5f)
        {
            timeToNextText = 0.0f;

            CurrentText++;
            if (CurrentText >= textToDisplay.Count)
            {
                CurrentText = 0;
            }
            Text.text = textToDisplay[CurrentText];
        }
    }
}