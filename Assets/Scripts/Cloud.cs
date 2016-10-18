using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {

    private float rand;

	// Use this for initialization
	void Start () {

        rand = Random.Range(50, 125);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 left = Vector3.left * Time.deltaTime * rand;
        transform.Translate(left);

        if (transform.position.x < -1300)
        {
            transform.position = new Vector3(4800, transform.position.y, transform.position.z);
            rand = Random.Range(50, 125);
        }
    }
}
