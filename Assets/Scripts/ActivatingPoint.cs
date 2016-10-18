using UnityEngine;
using System.Collections;

public class ActivatingPoint : MonoBehaviour {

    private bool activated;
    private bool allowed = true;
    private float timer;
    private bool firstActivate;

	// Use this for initialization
	void Awake () {
        activated = false;
	}
	

    public void activate()
    {
        activated = true;
    }

    public void deactivate()
    {
        activated = false;
    }

    public bool isActive()
    {
        return activated;
    }

    void OnTriggerEnter()
    {
        if (!GetComponentInChildren<ActivatableObject>().isActive() && allowed && GetComponentInChildren<ActivatableObject>().GetComponent<BridgeNew>() == null)
        {
            activate();
            GetComponentInChildren<ActivatableObject>().activate();
        }
        if (allowed && GetComponentInChildren<ActivatableObject>().GetComponent<BridgeNew>() != null)
        {
            timer = Time.realtimeSinceStartup;
        }

    }

    void OnTriggerExit()
    {
        if (GetComponentInChildren<Energy>() != null)
        {
            deactivate();
            GetComponentInChildren<ActivatableObject>().deactivate();
        }
        timer = 0;
        
    }

    void OnTriggerStay()
    {
        if (allowed && GetComponentInChildren<ActivatableObject>().GetComponent<BridgeNew>() != null)
        {
            if (Time.realtimeSinceStartup - timer >= 2f && !firstActivate)
            {
                Debug.Log("Bridge activated in point");
                firstActivate = true;
                activate();
                GetComponentInChildren<ActivatableObject>().activate();
            }
        }
    }

    public void disablePoint()
    {
        allowed = false;
    }

    public void enablePoint()
    {
        allowed = true;
    }

    public bool isAllowed()
    {
        return allowed;
    }
    public void setFirstActivate(bool fA)
    {
        firstActivate = fA;
    }
}
