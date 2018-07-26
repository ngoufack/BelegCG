using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Date : MonoBehaviour {
    private Text date;
	// Use this for initialization
	void Start () {
        date = GetComponent<Text>();
  
	}
	
	// Update is called once per frame
	void Update () {
        DateTime s = System.DateTime.Now;
        DateTime time = DateTime.Now;
        String day = LeadingZero(s.Date);
        String month = LeadingZero(s.Month);
        String year = LeadingZero(s.Year);
        String hour = LeadingZero(time.Hour);
        String minute = LeadingZero(time.Minute);
        String second = LeadingZero(time.Second);
        date.text = day+":" + month + ":" + year + ":" + hour + ":" + minute + ":" + second;
    

    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }

    string LeadingZero(DateTime n)
    {
        n= System.DateTime.Now;
        return n.ToString().PadLeft(2, '0');
    }
}
