using UnityEngine;
using System.Collections;

public class PlanetTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<WoolpyControler>() != null && other.GetComponent<WoolpyControler>().gravityChangeAllowed && other.GetComponent<WoolpyControler>().state != WoolpyState.FALLING)
        {
            other.GetComponent<WoolpyControler>().state = WoolpyState.PLANET;
            other.GetComponent<WoolpyControler>().transform.SetParent(GameObject.Find("Woolpies").transform);
            other.GetComponent<WoolpyControler>().setPlanetGravity(gameObject.GetComponentInParent<Planet>().gameObject);
            other.GetComponent<WoolpyControler>().gravityChangeAllowed = false;
            other.GetComponent<WoolpyControler>().changeWalkingDirection(true);
            StartCoroutine(allowGravityChange(other));
        }
        
        
    }

    private IEnumerator allowGravityChange(Collider woolpy)
    {
        yield return new WaitForSeconds(1f);
        woolpy.GetComponent<WoolpyControler>().gravityChangeAllowed = true;
    }
}
