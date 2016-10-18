using UnityEngine;
using System.Collections;

public class BridgeTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        
        if (!gameObject.GetComponentInParent<BridgeNew>().triggerExit && other.GetComponent<WoolpyControler>() != null)
        {
            activateBridge(other);
        }
     }
        
    void OnTriggerExit(Collider other)
    {
        if (gameObject.GetComponentInParent<BridgeNew>().triggerExit && other.GetComponent<WoolpyControler>() != null)
        {
            other.GetComponent<WoolpyControler>().setNormalGravity();
            StartCoroutine(waitActivateBridge(other));
        }
    }

    private IEnumerator waitActivateBridge(Collider other)
    {
        yield return new WaitForSeconds(0.3f);
        activateBridge(other);
    }

    private void activateBridge(Collider other)
    {
        other.GetComponent<WoolpyControler>().state = WoolpyState.BRIDGE;
        other.GetComponent<WoolpyControler>().transform.parent = GameObject.Find("Woolpies").transform;
        other.GetComponent<WoolpyControler>().setBridgeGravity(transform.parent.GetChild(0).gameObject);
        other.GetComponent<WoolpyControler>().gravityChangeAllowed = false;
        

        if (gameObject.GetComponentInParent<BridgeNew>().left)
        {
            other.GetComponent<WoolpyControler>().changeWalkingDirection(false);
        }
        else
        {
            other.GetComponent<WoolpyControler>().changeWalkingDirection(true);
        }

        StartCoroutine(allowGravityChange(other));
    }

    private IEnumerator allowGravityChange(Collider woolpy)
    {
        yield return new WaitForSeconds(1f);
        woolpy.GetComponent<WoolpyControler>().gravityChangeAllowed = true;
    }
}

