using UnityEngine;
using System.Collections;

public class PlatformTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<WoolpyControler>() != null /*&& other.GetComponent<WoolpyControler>().gravityChangeAllowed*/)
        {
            Debug.Log("platform trigger enter");
            other.GetComponent<WoolpyControler>().state = WoolpyState.PLATFORM;
            other.GetComponent<WoolpyControler>().transform.parent = GameObject.Find("Woolpies").transform;
            
            other.GetComponent<WoolpyControler>().setNormalGravity();
            other.GetComponent<WoolpyControler>().gravityChangeAllowed = false;
            other.GetComponent<WoolpyControler>().changeWalkingDirection(true);
            StartCoroutine(allowGravityChange(other));
        }
        
    }

    private IEnumerator allowGravityChange(Collider woolpy)
    {
        yield return new WaitForSeconds(0.3f);
        woolpy.GetComponent<WoolpyControler>().gravityChangeAllowed = true;
    }
}
