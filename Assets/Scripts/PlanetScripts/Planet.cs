using UnityEngine;
using System.Collections;
using System;

public class Planet : MonoBehaviour {

    //private GameObject[] woolpies;
    //private float distance;

	// Update is called once per frame
	void Update () {




        /*woolpies = GameObject.FindGameObjectsWithTag("Woolpy");

        foreach (GameObject woolpy in woolpies)
        {
            distance = Vector3.Distance(woolpy.transform.position, transform.position);
            //Debug.Log(transform.lossyScale.x / 2 + 100);
            if (distance < transform.lossyScale.x/2 + 125)
            {
                if (woolpy.GetComponent<FauxGravityBodies>() == null /*&& woolpy.GetComponent<WoolpyControler>().planetEnabled)
                {
                    woolpy.GetComponent<WoolpyControler>().setPlanetGravity(gameObject);
                    woolpy.GetComponent<WoolpyControler>().state = WoolpyState.PLANET;
                    woolpy.GetComponent<WoolpyControler>().setWalkingDirection(true);
                    woolpy.GetComponent<WoolpyControler>().planetEnabled = false;
                    StartCoroutine(SetBridgeDisabled(woolpy));   //Enable to go on bridge after half a second
                    
                }

            }
        }*/
    }

   /* private IEnumerator SetBridgeDisabled(GameObject woolpy)
    {
        yield return new WaitForSeconds(0.3f);
        woolpy.GetComponent<WoolpyControler>().bridgeEnabled = true;
    }*/
}
