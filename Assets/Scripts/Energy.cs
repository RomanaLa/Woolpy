using UnityEngine;
using System.Collections;
using System;

public class Energy : ActivatableObject
{
    private bool active;
    public GameObject portalButton;

    public override void activate()
    {
        if (!active)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            //while (this.animator.GetCurrentAnimatorStateInfo(0).IsName("YourAnimationName"))
            { 
                // Avoid any reload.
            }
            active = true;
            portalButton.GetComponent<SpriteRenderer>().enabled = true;
        }
        
    }

    public override void deactivate()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        portalButton.GetComponent<SpriteRenderer>().enabled = false;
        //while (this.animator.GetCurrentAnimatorStateInfo(0).IsName("YourAnimationName"))
        {
            // Avoid any reload.
        }
        active = false;
    }

    public override bool isActive()
    {
        return active;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("activate Energy");
        activate();
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("deactivate Energy");
        deactivate();
    }
}
