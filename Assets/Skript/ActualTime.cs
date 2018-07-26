using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class ActualTime : MonoBehaviour {
    private Text textClock;

	// Use this for initialization
	void Start () {
        textClock = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        DateTime time = DateTime.Now;

   //DateTime date = System.DateTime.Now.ToString("MM/dd/yyyy");
        String hour = LeadingZero(time.Hour);
        String minute = LeadingZero(time.Minute);
        String second = LeadingZero(time.Second);
       //extClock.text = date;
        textClock.text =  hour + ":" + minute + ":" + second;

    }

     string LeadingZero(DateTime date)
    {
        return System.DateTime.Now.ToString("MM/dd/yyyy");
    }

    string LeadingZero(int n)
    {
       
   
            return n.ToString().PadLeft(2, '0');

    }
}
