using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

    private float distance;
    private GameObject[] woolpies;
	
	// Update is called once per frame
	void Update () {
        /*woolpies = GameObject.FindGameObjectsWithTag("Woolpy");
        foreach(GameObject woolpy in woolpies)
        {
            distance = Vector3.Distance(transform.position, woolpy.transform.position);
            if (distance < transform.lossyScale.x/2 + 50)
            {
                if (woolpy.GetComponent<WoolpyControler>().gravityChangeAllowed)
                {
                    woolpy.transform.up = transform.up;
                    woolpy.GetComponent<WoolpyControler>().setNormalGravity();
                    woolpy.GetComponent<WoolpyControler>().gravityChangeAllowed = false;
                    woolpy.GetComponent<WoolpyControler>().state = WoolpyState.PLATFORM;
                    woolpy.GetComponent<WoolpyControler>().setWalkingDirection(true);
                    StartCoroutine(allowGravityChange(woolpy));
                }
                
            }
        }*/
        
    }

    private IEnumerator allowGravityChange(GameObject woolpy)
    {
        yield return new WaitForSeconds(0.3f);
        woolpy.GetComponent<WoolpyControler>().gravityChangeAllowed = true;
    }
}
