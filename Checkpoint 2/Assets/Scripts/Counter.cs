﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    public GameController gameController;
    private int Count = 0;

    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Counting();
    }
    void Counting()
    {
        Count += 1;
        CounterText.text = "Count : " + Count;
        
    }
}
