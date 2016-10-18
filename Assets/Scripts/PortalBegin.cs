using UnityEngine;
using System.Collections;
using System;

public class PortalBegin : ActivatableObject
{

    private float distance;
    public GameObject[] woolpies;
    //public GameObject planet;
    public GameObject portalEnd;
    public bool active = false;

    public override void activate()
    {
        Transform child = transform.parent.parent.GetChild(0);
        /*foreach(Transform child in transform.parent.parent)
        {
            if (child.name != this.transform.parent.name)    //get the activating point for the energy
            {*/
        if (child.GetComponent<ActivatingPoint>().isActive() && !active)
        {
            active = true;
            MeshRenderer[] renderer = gameObject.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer r in renderer)
            {
                r.enabled = true;
            }
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
            //gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Collider>().enabled = true;
            //portalEnd.GetComponent<MeshRenderer>().enabled = true;
            renderer = portalEnd.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer r in renderer)
            {
                r.enabled = true;
            }
            portalEnd.GetComponentInChildren<ParticleSystem>().Play();
            StartCoroutine(countDown()); //disable portal after 5 seconds
        }
        //}
        //}



    }

    private IEnumerator countDown()
    {
        yield return new WaitForSeconds(5.0f);
        deactivate();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<WoolpyControler>() != null && GetComponentInParent<ActivatingPoint>().isActive() && distance < 0.3)
        {
            other.GetComponent<WoolpyControler>().playPortalAudio();
            MeshRenderer[] woolpieParts = other.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer m in woolpieParts)
            {
                if (m != null)
                {
                    m.enabled = false; //make woolpy invisible
                }
            }
            StartCoroutine(transportWoolpy(0.5f, other.gameObject)); //wait half a second before transporting woolpy to end of portal


        }
    }

    /*void Update()
    {
         woolpies = GameObject.FindGameObjectsWithTag("Woolpy");

        foreach (GameObject woolpy in woolpies)
        {
            distance = Vector3.Distance(woolpy.transform.position, transform.position);
            if (GetComponentInParent<ActivatingPoint>().isActive() && distance < 0.3)
            {
                woolpy.GetComponent<MeshRenderer>().enabled = false;
                StartCoroutine(transportWoolpy(0.5f, woolpy)); //wait half a second before transporting woolpy to end of portal

                
            }
        }
    }*/

    private IEnumerator transportWoolpy(float s, GameObject woolpy)
    {
        yield return new WaitForSeconds(s);

        Vector3 position = new Vector3(portalEnd.transform.position.x, portalEnd.transform.position.y, portalEnd.transform.position.z);
        woolpy.transform.up = portalEnd.transform.up;
        woolpy.transform.position = position;
        woolpy.GetComponent<MeshRenderer>().enabled = true;
        //woolpy.GetComponent<WoolpyControler>().setPlanetGravity(planet);
        //woolpy.GetComponent<WoolpyControler>().setState(WoolpyState.PLANET);
    }

    public override void deactivate()
    {
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        MeshRenderer[] renderer = gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer r in renderer)
        {
            r.enabled = false;
        }
        gameObject.GetComponentInChildren<ParticleSystem>().Clear();
        gameObject.GetComponentInChildren<ParticleSystem>().Stop();

        gameObject.GetComponent<Collider>().enabled = false;
        //portalEnd.GetComponent<MeshRenderer>().enabled = false;
        renderer = portalEnd.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer r in renderer)
        {
            r.enabled = false;
        }
        portalEnd.GetComponentInChildren<ParticleSystem>().Clear();
        portalEnd.GetComponentInChildren<ParticleSystem>().Stop();

        portalEnd.transform.parent.GetComponentInChildren<ActivatingPoint>().deactivate();
        active = false;
    }

    public override bool isActive()
    {
        return active;
    }
}
