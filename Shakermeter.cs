﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shakermeter : MonoBehaviour {

    [SerializeField]
    private Arduino arduino;
    [SerializeField]
    private Image shakeBar;
    [SerializeField]
    private GameObject shakerMeter;
    [SerializeField]
    private CheckScript cs;
    [SerializeField]
    private LidScript ls;
    private Rigidbody rb;

    public bool isShaken;
    public bool runOnce;

    private float originalYAxis;
    private float barScale;
    private float lastXPos;

    

    // Use this for initialization
    void Start () {

        //Setting up parts shake meter for the start of the game
        originalYAxis = transform.position.y;
        barScale = 0.1f;
        shakerMeter.SetActive(false);
        rb = GetComponentInChildren<Rigidbody>();
        runOnce = false;

    }
	
	// Update is called once per frame
	void Update () {

        if (ls != null)
        {
            //When the lid is open the player can add ingrediants
            if (cs != null && !ls.lidIsOpen)
            {
                //When ingrediants have been added the player can shake the cocktail and will put it into a set position
                if (cs.isMade && !runOnce)
                {
                    shakerMeter.SetActive(true);
                    isShaken = false;
                    transform.position = new Vector3(0, originalYAxis, 0);
                    rb.isKinematic = true;

                    //Checking to see if the acceloration has changed
                    if (arduino.shakerPos.x < lastXPos || arduino.shakerPos.x > lastXPos)
                    {
                        shakeBar.rectTransform.localScale += new Vector3(barScale * (Time.deltaTime * 0.8f), 0, 0);
                    }
                }
            }
        }

        
        
        
        //As the player shakes the controller, the bar will increase in size
        if (shakeBar.rectTransform.localScale.x >= 1 && !runOnce)
        {
            runOnce = true;
            shakeBar.rectTransform.localScale = new Vector3(0,1,1);
            isShaken = true;
            shakerMeter.SetActive(false);
            rb.isKinematic = false;
        }
	}

    //The shaker's previous position is stored in lastXpos;
    private void LateUpdate()
    {
        lastXPos = arduino.shakerPos.x;
    }
}
