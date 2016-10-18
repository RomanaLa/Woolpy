using UnityEngine;
using System.Collections;

public class animationstart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<Animation>().Play ("Take 001");
		
	}
}
