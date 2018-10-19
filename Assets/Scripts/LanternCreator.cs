using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternCreator : MonoBehaviour {

    public int backgroundLanternCount = 1000;
    public int foregroundLanternCount = 100;

    GameObject[] foregroundLanterns = null;
    GameObject[] backgroundLanterns = null;

    float[] fgLanternRotationSpeeds = null;

    public GameObject fgLanternTemplate, bgLanternTemplate;

    public GameObject fgLanternSource;
    public GameObject[] fgLanternTargets;

    public GameObject fgLanternParent;
	// Use this for initialization
	void Start () {

        fgLanternRotationSpeeds = new float[foregroundLanternCount];
        foregroundLanterns = new GameObject[foregroundLanternCount];

        int iLanternDestIndex = 0; 
        for (int iIndex = 0; iIndex < foregroundLanternCount; iIndex++)
        {
            try
            {
                float fX = fgLanternSource.transform.position[0] + Random.Range(-30, 0);
                float fY = Random.Range(-50, 10) + fgLanternSource.transform.position[1];
                float fZ = fgLanternSource.transform.position[2] + Random.Range(-40, 30); // To ensure that we have sufficient time between respawning
                Vector3 pos = new Vector3(fX, fY, fZ);
                GameObject lantern;

                lantern = fgLanternTemplate;
                fgLanternRotationSpeeds[iIndex] = Random.Range(-0.5f, 0.5f);


                Quaternion rotation = new Quaternion(0, 0, 0, 0);
                foregroundLanterns[iIndex] = Instantiate(lantern, pos, rotation);

                foregroundLanterns[iIndex].transform.parent = fgLanternParent.transform;

                var lanternMovementScript = foregroundLanterns[iIndex].GetComponent<LanternMovement>();
                lanternMovementScript.fgLanternSource = fgLanternSource;
                lanternMovementScript.fgLanternTarget = fgLanternTargets[iLanternDestIndex++];
                if (iLanternDestIndex == fgLanternTargets.Length)
                    iLanternDestIndex = 0;

                lanternMovementScript.rotationSpeed = Random.Range(-3.5f, 3.5f);
            }
            catch (System.Exception ex)
            {
                Debug.Log(ex);
            }

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
