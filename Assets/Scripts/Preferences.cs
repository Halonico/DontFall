﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preferences : MonoBehaviour {

    public Text scoreText;
    /*
     * This method load the score of the user
     */
	void Start () {
        scoreText.text = "SCORE\n" + PlayerPrefs.GetInt("High Score");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
