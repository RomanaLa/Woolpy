using UnityEngine;
using System.Collections;
using System;

public class Catapulte : ActivatableObject {

    public int xForce;  //in millions
    public int yForce;  //in millions

    public override void activate()
    {
        
    }

    public override void deactivate()
    {
        
    }

    public override bool isActive()
    {
        return true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<WoolpyControler>() != null)
        {
            other.GetComponent<WoolpyControler>().setNormalGravity();
            other.GetComponent<WoolpyControler>().state = WoolpyState.FLYING;
            other.GetComponent<Rigidbody>().AddForce(new Vector3(xForce * 1000000, yForce * 1000000, 0));
        }
        
    }

}
