using UnityEngine;
using System.Collections;

public class ActivePortal : MonoBehaviour {

    public GameObject portalEnd;
    public bool active = false;
    private float distance;

    void OnTriggerEnter(Collider other)
    {
            //other.GetComponent<MeshRenderer>().enabled = false; //make woolpy invisible
            transportWoolpy(0.5f, other.gameObject); //wait half a second before transporting woolpy to end of portal

    }

    private void transportWoolpy(float s, GameObject woolpy)
    {
        Vector3 position = new Vector3(portalEnd.transform.position.x, portalEnd.transform.position.y, portalEnd.transform.position.z);
        woolpy.transform.up = portalEnd.transform.up;
        woolpy.transform.position = position;
        //woolpy.transform.eulerAngles = new Vector3(woolpy.transform.eulerAngles.x, 90, woolpy.transform.eulerAngles.z);
        
        woolpy.GetComponent<WoolpyControler>().setStartingRotation();

       // woolpy.GetComponent<MeshRenderer>().enabled = true;
        //woolpy.GetComponent<WoolpyControler>().setPlanetGravity(planet);
        //woolpy.GetComponent<WoolpyControler>().setState(WoolpyState.PLANET);
    }
}
