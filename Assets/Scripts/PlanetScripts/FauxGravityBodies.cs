using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class FauxGravityBodies : MonoBehaviour {

    public FauxGravityAttractor attractor;
    private Transform myTransform;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().useGravity = false;
        myTransform = transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        //GetComponent<Rigidbody>().useGravity = true;
        attractor.Attract(transform);
	}

    public void setAttractor(GameObject a)
    {
        attractor = a.GetComponent<FauxGravityAttractor>();
    }

}
