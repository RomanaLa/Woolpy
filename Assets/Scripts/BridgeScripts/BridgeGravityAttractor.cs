using UnityEngine;
using System.Collections;

public class BridgeGravityAttractor: MonoBehaviour {
    private float gravity = -1000000;

    public void Attract(Transform body)
    {
        //Vector3 gravityUp = (body.position - transform.position).normalized;

        body.GetComponent<Rigidbody>().AddForce(transform.up * gravity);

        body.rotation = transform.parent.rotation;
    }
}
