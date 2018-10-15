using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternMovement : MonoBehaviour {

    public GameObject fgLanternSource, fgLanternTarget;

    public float lanternSpeed = 1f;

    const int closeEnough = 10;

    public float rotationSpeed = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (fgLanternTarget == null)
        {
            return;
        }

        this.transform.position = Vector3.MoveTowards(this.transform.position, fgLanternTarget.transform.position, lanternSpeed * Time.deltaTime);

        //this.transform.LookAt(fgLanternTarget.transform.position); // Make the meteor face the destination

        transform.Rotate(0, rotationSpeed, 0);

        // If it is very close to the target, reset the position
        if (fgLanternTarget.transform.position.z < (this.transform.position.z + closeEnough))
        {
            

            float fX = fgLanternSource.transform.position[0] + Random.Range(-30, 30);
            float fY = Random.Range(-50, 10) + fgLanternSource.transform.position[1];
            float fZ = fgLanternSource.transform.position[2] + Random.Range(-40, 30); // To ensure that we have sufficient time between respawning
            Vector3 pos = new Vector3(fX, fY, fZ);

            this.transform.position = pos;

        }
    }
}
