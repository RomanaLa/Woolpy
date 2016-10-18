using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour
{

    public GameObject[] points;
    private Vector3 lastPos;
    private Vector3 startRot;
    private Boolean rotatedLeft;
    private Boolean rotatedRight;
    private Boolean rotatedUp;
    private Boolean rotatedDown;
    private Boolean rotated;
    private int counter = 0;

    void Start()
    {
        points = GameObject.FindGameObjectsWithTag("Activating Point");
        lastPos = transform.position;
        startRot = transform.eulerAngles;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<WoolpyControler>() != null && other.GetComponent<WoolpyControler>().state == WoolpyState.FALLING)
        {
            other.transform.parent = this.transform;
            other.GetComponent<WoolpyControler>().setNoGravity();
        }
    }

    void FixedUpdate()
    {
        counter++;
        if (counter >= 20)
        {
            checkRotation();
            counter = 0;
        }

    }

    private void checkRotation()
    {
        if (transform.position.x - lastPos.x > 10) //if the player moves to the right
        {
            if (!rotatedRight)
            {
                if (!rotatedLeft)
                {
                    rotateYBy(-20);
                } else
                {
                    rotateYBy(-40);
                    rotatedLeft = false;
                }
                rotatedRight = true;
            }
        } else if (lastPos.x - transform.position.x > 10) //if the player moves to the left
        {
            if (!rotatedLeft)
            {
                if (!rotatedRight)
                {
                    rotateYBy(20);
                } else
                {
                    rotateYBy(40);
                    rotatedRight = false;
                }
                rotatedLeft = true;
            }
        }

       /* if (transform.position.y - lastPos.y > 10) //if the player moves up
        {
            if (!rotatedUp)
            {
                if (!rotatedDown)
                {
                    rotateXBy(20);
                }
                else
                {
                    rotateXBy(40);
                    rotatedDown = false;
                }
                rotatedUp = true;
            }
        }
        else if (lastPos.y - transform.position.y > 10) //if the player moves down
        {
            if (!rotatedDown)
            {
                if (!rotatedUp)
                {
                    rotateXBy(-20);
                }
                else
                {
                    rotateXBy(-40);
                    rotatedUp = false;
                }
                rotatedDown = true;
                
            }
        }*/
       else {
            rotatedRight = false;
            rotatedLeft = false;
            rotatedUp = false;
            rotatedDown = false;
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, startRot, Time.deltaTime * 50);
        }

        lastPos = transform.position;
    }

    private void rotateYBy(int degrees)
    {
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + degrees, transform.eulerAngles.z), Time.deltaTime * 50);
    }

    private void rotateXBy(int degrees)
    {
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(transform.eulerAngles.x + degrees, transform.eulerAngles.y, transform.eulerAngles.z), Time.deltaTime * 50);
    }
}
