﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peligro1 : MonoBehaviour
{

    AudioSource myAudio;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        Invoke("playAudio", 1.4f);

    }

    void playAudio()
    {
        myAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
