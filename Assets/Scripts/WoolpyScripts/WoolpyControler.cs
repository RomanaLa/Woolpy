using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class WoolpyControler : MonoBehaviour {

    private GameObject[] bridges;
    private GameObject[] platforms;
    private GameObject planet1;
    private GameObject trampoline;
    private GameObject portal;
    private GameObject portal_1;
    private GameObject planet2;

    public float distance;
    public int state = WoolpyState.PLANET;
    private bool walkingDirection = true; // true -> right, false -> left
    //public bool planetEnabled = true;   //if it is allowed to go on a planet
    //public bool bridgeEnabled = true;  //if it is allowed to go on a bridge
    //public List<Bridge> crossedBridges = new List<Bridge>();
    public bool gravityChangeAllowed = true;
    private bool isWalking = true;
    private Quaternion startingRotation;
    private Animator animator;
    private float distToGround;
    private float animatorSpeed;
   /* public AudioClip die;
    public AudioClip portalSound;
    public AudioClip catapulte;
    public AudioClip steps;*/

    // Use this for initialization
    void Start () {

        planet1 = GameObject.Find("Planet (1)");
        //trampoline = GameObject.Find("trampoline");

        //planet2 = GameObject.Find("planet2");
        startingRotation = transform.rotation;
        distToGround = GetComponent<Collider>().bounds.extents.y;

        animator = GetComponent<Animator>();
        animatorSpeed = animator.speed;
        animator.speed = UnityEngine.Random.Range(0, 2000);
        StartCoroutine(animatorWait());


    }

    private IEnumerator animatorWait()
    {
        yield return new WaitForSeconds(0.1f);
        animator.speed = animatorSpeed;
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
	
    void OnCollisionEnter(Collision col)
    {
        //this.GetComponent<Rigidbody>().isKinematic = true;
        //other.GetComponent<Rigidbody>().isKinematic = true;
        //if (this.)
        //isWalking = false;
    }

    /*void OnCollisionStay(Collision col)
    {
        if (isGrounded())
        {
            
            animator.SetBool("colliding", true);
        }
    }*/

    void OnCollisionExit(Collision col)
    {
        //this.GetComponent<Rigidbody>().isKinematic = false;
        //other.GetComponent<Rigidbody>().isKinematic = false;

        /*if (state == WoolpyState.FALLING)
        {
            animator.SetBool("colliding", false);
        }*/
        

    }
	
	void Update () {
       /* else
        {
            animator.SetBool("colliding", false);
        }*/
        //find objects that aren't active from the start
        bridges = GameObject.FindGameObjectsWithTag("Bridge");
        platforms = GameObject.FindGameObjectsWithTag("Platform");
        //portal = GameObject.Find("portal");
        //portal_1 = GameObject.Find("portal (1)");

        //woolpy running
        //why is there no walking direction needed???
        if (isWalking)

        {
            Vector3 forward = Vector3.forward * Time.deltaTime * 125;
            transform.Translate(forward);
        }
       /* if (walkingDirection)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 90, transform.rotation.z);
        }
        else if (!walkingDirection)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 180, transform.rotation.z);
        }*/
       

        if (state != WoolpyState.BRIDGE || GetComponent<FauxGravityBodies>() != null)
        {
            foreach (GameObject b in bridges)
            {
                Physics.IgnoreCollision(b.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
            }
            
        }
        if (state == WoolpyState.BRIDGE || GetComponent<BridgeGravityBodies>() != null)
        {
            //GetComponent<AudioSource>().clip = steps;
            //GetComponent<AudioSource>().Play();
            foreach (GameObject b in bridges)
            {
                Physics.IgnoreCollision(b.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), false);
            }

        }

        if(state != WoolpyState.PLATFORM)
        {
            foreach (GameObject p in platforms)
            {
                Physics.IgnoreCollision(p.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
            }

        }
        if (state == WoolpyState.PLATFORM)
        {
            foreach (GameObject p in platforms)
            {
                Physics.IgnoreCollision(p.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), false);
            }

        }

        if (state == WoolpyState.FALLING || state == WoolpyState.FLYING)
        {
            
            animator.SetBool("colliding", false);
        }
        else
        {
            animator.SetBool("colliding", true);
        }
        
        if (state == WoolpyState.FALLING)
        {
            //GetComponent<AudioSource>().clip = die;
            //GetComponent<AudioSource>().Play();
        } else if(state == WoolpyState.FLYING)
        {
            //GetComponent<AudioSource>().clip = catapulte;
            GetComponent<AudioSource>().Play();
        }


    }

    public void playPortalAudio()
    {
        //GetComponent<AudioSource>().clip = portalSound;
        //GetComponent<AudioSource>().Play();
    }

    public void changeWalkingDirection(bool direction) //true -> right, false -> left
    {
        if (direction)
        {
            transform.rotation = startingRotation;
        }
        /*else
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
        }*/

    }

    public void setNormalGravity()
    {
        if (gravityChangeAllowed)
        {
            isWalking = true;
            GetComponent<Rigidbody>().useGravity = true;
            Destroy(GetComponent<FauxGravityBodies>());
            Destroy(GetComponent<BridgeGravityBodies>());
            transform.eulerAngles = new Vector3(0, 0, 0);
            //if(transform.parent.GetComponent<Player>() != null)
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            } //else
            {
                //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
            
        }
        

    }

    public void setNoGravity()
    {
        if (gravityChangeAllowed)
        {
            isWalking = false;
            GetComponent<Rigidbody>().useGravity = false;
            Destroy(GetComponent<FauxGravityBodies>());
            Destroy(GetComponent<BridgeGravityBodies>());
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }


    }

    public void setPlanetGravity(GameObject planet)
    {
        if (gravityChangeAllowed)
        {
            isWalking = true;
            //Destroy bridge gravity script so the woolpy won't be attracted from the bridge
            Destroy(GetComponent<BridgeGravityBodies>());

            gameObject.AddComponent<FauxGravityBodies>();
            GetComponent<FauxGravityBodies>().setAttractor(planet);
           

        }
        

    }

    public void setBridgeGravity(GameObject bridge)
    {
        if (gravityChangeAllowed)
        {
            isWalking = true;
            //Destroy planet gravity script so the woolpy won't be attracted from the planet
            Destroy(GetComponent<FauxGravityBodies>());

            gameObject.AddComponent<BridgeGravityBodies>();
            GetComponent<BridgeGravityBodies>().setAttractor(bridge);
        }
        
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }

    public void setState(int s)
    {
        state = s;
    }

    public void setStartingRotation()
    {
        transform.rotation = startingRotation;
    }

    /*public void addCrossedBridge(Bridge b)
    {
        crossedBridges.Add(b);
    }

    public bool checkBridge(Bridge b)
    {
        if (crossedBridges.Contains(b))
        {
            return true;
        }
        else
        {
            return false;
        }
    }*/

}
