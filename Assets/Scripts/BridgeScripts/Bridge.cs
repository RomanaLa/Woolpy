using UnityEngine;
using System.Collections;
using System;

public class Bridge : ActivatableObject{

    //public float distance;
    
    //public float XThreshold;   //woolpy has to be over this value (x-axis)
    //public float YThreshold;   //woolpy has to be over this value (y-axis)
    public bool triggerExit; //if the bridge gravity should be activated on trigger exit
    public bool left;   //if the woolpy should go left
    //private GameObject[] woolpies;
    //private bool bridgeEnabled = false;
    //private long dt;    //time since script was added
    public BoxCollider Trigger; //the collider that should trigger that the woolpy is now on the bridge
    private bool active = false;

    public override void activate()
    {
        if (!active)
        {
            active = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        
            Trigger.enabled = true;
            StartCoroutine(countDown());
            
        }
        
    }

    void Update()
    {

        }

    private IEnumerator countDown()
    {
        yield return new WaitForSeconds(7.0f);
        deactivate();

    }

   /* private IEnumerator SetPlanetDisabled(GameObject woolpy)
    {
        yield return new WaitForSeconds(0.3f);
        woolpy.GetComponent<WoolpyControler>().planetEnabled = true;
    }*/

    public override void deactivate()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        Trigger.enabled = false;
        active = false;
    }

    public override bool isActive()
    {
        return active;
    }
}

