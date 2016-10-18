using UnityEngine;
using System.Collections;

public class FauxGravityAttractor : MonoBehaviour {
    private float gravity = -1000000;
    private float oldGravityUp;

    public void Attract(Transform body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;

        body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        //difference between rotations
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;

        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
        
    }
/*
    public void Attract(Transform body)
    {
        float gravity = 10;
       
            body.GetComponent<Rigidbody>().velocity = ((-body.position + transform.position) * gravity);
            body.LookAt(transform.position);
        
    }*/

    public void setGravity(float g)
    {
        gravity = g;
    }
}
