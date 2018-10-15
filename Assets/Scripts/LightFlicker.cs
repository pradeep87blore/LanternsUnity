using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

    public Light lightToPulse;

    const int MAXCOLORS = 5;
    Color[] lightColors;
    int colorChangeIterator = 0;
    int colorChangeSpeedIterator = 0;
    int COLORCHANGENOW = 5;
	// Use this for initialization
	void Start () {
        lightColors = new Color[MAXCOLORS];

        lightColors[0] = Color.yellow;
        lightColors[1] = new Color(1, (float)(162.0 / 255.0), 0); // Orange
        lightColors[2] = Color.red;
        lightColors[3] = Color.white;
        lightColors[4] = new Color(1, (float)(162.0 / 255.0), 0); // Orange
    }
	
	// Update is called once per frame
	void Update () {

        if (colorChangeSpeedIterator++ < COLORCHANGENOW)
            return;

        colorChangeSpeedIterator = 0;

        lightToPulse.color = lightColors[colorChangeIterator++];
        if (colorChangeIterator == lightColors.Length)
            colorChangeIterator = 0;
    }
}
