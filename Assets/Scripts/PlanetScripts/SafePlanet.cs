using UnityEngine;
using System.Collections;

public class SafePlanet : Planet {

    private GameObject[] woolpies;
    private float distance;
    public GameObject nextLevelButton;
    private bool safe;


	// Update is called once per frame
	void Update () {

        woolpies = GameObject.FindGameObjectsWithTag("Woolpy");
        foreach(GameObject woolpy in woolpies)
        {
            distance = Vector3.Distance(woolpy.transform.position, transform.position);
            
            if (distance > transform.lossyScale.x / 2 + 100)
            {
                safe = false;
                break;
            }
            else
            {
                safe = true;
                
            }
        }
        if (safe)
        {
            nextLevelButton.GetComponent<SpriteRenderer>().enabled = true;
        }
	}
}
