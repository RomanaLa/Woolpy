using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class BridgeGravityBodies : MonoBehaviour {

    public BridgeGravityAttractor attractor;
    public Transform myTransform;

    // Use this for initialization
    void Awake()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().useGravity = false;
        myTransform = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        attractor.Attract(myTransform);
    }

    public void setAttractor(GameObject a)
    {
        attractor = a.GetComponent<BridgeGravityAttractor>();
    }
}
