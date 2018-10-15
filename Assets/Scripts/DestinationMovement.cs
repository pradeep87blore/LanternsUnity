using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationMovement : MonoBehaviour {

    public GameObject leftMost, rightMost;
    bool bMoveLeft = true;

    public float fSpeed = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(bMoveLeft == true)
        {
            var newPos = transform.position;
            newPos.x -= fSpeed;

            transform.position = newPos;
            if (newPos.x <= leftMost.transform.position.x)
            {
                bMoveLeft = false;
                return;
            }
        }
        else
        {
            var newPos = transform.position;
            newPos.x += fSpeed;

            transform.position = newPos;
            if (newPos.x >= rightMost.transform.position.x)
            {
                bMoveLeft = true;
                return;
            }
        }
	}
}
