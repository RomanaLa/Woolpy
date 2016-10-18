using UnityEngine;
using System.Collections;
using System;

public class BridgeNew : ActivatableObject
{
    public GameObject[] bridgeTiles;
    private Animator animator;
    private float timer;
    private float timerNow;
    private float activationTime;
    public Collider bridgeCollider;
    public Collider trigger;
    private bool active;
    public bool triggerExit; //if the bridge gravity should be activated on trigger exit
    public bool left;   //if the woolpy should go left
    private int counter;
    private bool deactivating;
    private bool activateCalled;
    private int length;


    void Awake()
    {
        timer = 0;
        activationTime = float.MaxValue;
        counter = 0;
        deactivating = false;
        activateCalled = false;
        animator = GetComponent<Animator>();
        length = bridgeTiles.Length;
    }

    void Update()
    {
        
        timerNow = Time.realtimeSinceStartup;
        if (timerNow - timer >= 1f && counter < length && activateCalled && !deactivating)
        {
            activate();
        }
        //Debug.Log("Now: " + timerNow + "activated: " + activationTime);
        if (timerNow - activationTime >= 7)
        {
            deactivating = true;
        }
        if (deactivating && timerNow - timer >= 1f && counter > 0)
        {
            deactivate();
        }

    }

        

    public override void activate()
    {
            activateCalled = true;
            timer = Time.realtimeSinceStartup;
        //animator.Play("auf");
        animator.SetBool("open", true);
        bridgeTiles[counter].GetComponent<Renderer>().enabled = true;
        bridgeTiles[counter].GetComponent<Collider>().enabled = true;
        counter++;
        
        if (counter == length)
        {
            animator.SetBool("open", false);
            trigger.GetComponent<Collider>().enabled = true;
            bridgeCollider.GetComponent<Collider>().enabled = true;
            active = true;
            activationTime = Time.realtimeSinceStartup;
        }
        
    }

    public override void deactivate()
    {
        trigger.GetComponent<Collider>().enabled = false;
        bridgeCollider.GetComponent<Collider>().enabled = false;
        timer = Time.realtimeSinceStartup;
        //animator.Play("zu");
        animator.SetBool("close", true);
        counter--;
        bridgeTiles[counter].GetComponent<Renderer>().enabled = false;
        bridgeTiles[counter].GetComponent<Collider>().enabled = false;

        
        
        if (counter == 0)
        {
            animator.SetBool("close", false);
            
            active = false;
            activateCalled = false;
            activationTime = float.MaxValue;
            deactivating = false;
            GetComponentInParent<ActivatingPoint>().setFirstActivate(false);
        }
    }

    public override bool isActive()
    {
        return active;
    }

   


    //public GameObject bridgeTiles;
    //private bool active = false;
    //public double xOffset;
    //public double yOffset;
    //public int nrTiles;
    //public bool triggerExit; //if the bridge gravity should be activated on trigger exit
    //public bool left;   //if the woolpy should go left
    //public BoxCollider trigger; //the collider that should trigger that the woolpy is now on the bridge
    //public BoxCollider bridgeCollider;
    //private GameObject[] spawnedBridgeTiles;
    //private Animator animator;

    //void Start()
    //{
    //    spawnedBridgeTiles = new GameObject[nrTiles];
    //    animator = GetComponent<Animator>();
    //}

    //void Update()
    //{
    //    /*if (spawnedBridgeTiles[0] == null && GetComponentInParent<ActivatingPoint>().isAllowed())
    //    {
    //        GetComponentInParent<ActivatingPoint>().enablePoint();
    //    }*/
    //}

    //public override void activate()
    //{
        
        
    //    if (!active)
    //    {
    //       active = true;
    //        /*StartCoroutine(*/spawnTiles();
    //        //trigger.enabled = true;
    //        //bridgeCollider.enabled = true;
    //        animator.SetBool("open", true);
    //    }
       
    //}

    //public override void deactivate()
    //{
    //    if (active)
    //    {
    //        active = false;
    //        trigger.enabled = false;
    //        bridgeCollider.enabled = false;
    //        animator.SetBool("close", false);
    //    }
        
    //}

    //private void spawnTiles()
    //{
    //    Vector3 position = transform.position;
    //    Vector3 newPosition;
    //    for (int i = 0; i < nrTiles; i++)
    //    {
    //        newPosition = new Vector3((float)(position.x - bridgeTiles.transform.localScale.x/2.7 * xOffset), (float)(position.y - bridgeTiles.transform.localScale.y/2.7 * yOffset), position.z);
    //        //yield return new WaitForSeconds(0.75f);  //wait before spawning the next tile
    //        GameObject tile = (GameObject)Instantiate(bridgeTiles, newPosition, transform.rotation);
    //        tile.transform.parent = GameObject.FindGameObjectWithTag("World").transform;
    //        spawnedBridgeTiles[i] = tile;
    //        Destroy(tile, (float)(7 + (nrTiles - i) * 1.75));   //destroy tiles in reversed order
    //         StartCoroutine(startWiggle((float)(7 + (nrTiles - i) + 0.2)));
    //        StartCoroutine(countDown((float)(7 + (nrTiles - i) + 1)));  //deactivate bridge 
           
    //        position = newPosition;
    //    }
    //    trigger.enabled = true;
    //    bridgeCollider.enabled = true;
    //    animator.SetBool("open", false);
    //}

    //private IEnumerator countDown(float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    deactivate();
    //}

    //public override bool isActive()
    //{
    //    return active;
    //}

    //private IEnumerator startWiggle(float time)
    //{
        
    //    yield return new WaitForSeconds(time);
    //    for (int i = 0; i < spawnedBridgeTiles.Length; i++)
    //    {
    //        if (spawnedBridgeTiles[i] != null)
    //        {
    //            spawnedBridgeTiles[i].AddComponent<BridgeShake>();
    //            spawnedBridgeTiles[i].GetComponent<BridgeShake>().setDuration(nrTiles * 0.5f);
    //        }
    //    }
    //    animator.SetBool("close", true);
    //    //GetComponentInParent<ActivatingPoint>().disablePoint();
    //}
}
