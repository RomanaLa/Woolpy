using UnityEngine;
using System.Collections;

public class PlatformExitTrigger : MonoBehaviour {

    public ActivatingPoint continuative;

    void OnTriggerExit(Collider other)
    {
        if (!continuative.isActive() && other.GetComponent<WoolpyControler>() != null)
        {
            Debug.Log("Platform Exit Trigger");
            other.GetComponent<WoolpyControler>().state = WoolpyState.FALLING;
            other.GetComponent<WoolpyControler>().setNormalGravity();
        }
       
        
    }

}
