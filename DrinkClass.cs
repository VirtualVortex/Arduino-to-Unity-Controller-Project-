﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkClass : MonoBehaviour {
    
    private string ingrediantName;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Display the inputed name for the ingrediant
    public void Ingrediant(string ingrediantName)
    {
        transform.GetComponentInChildren<Text>().text = ingrediantName;
    }
}
