using UnityEngine;
using System.Collections;

public class movieStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MovieTexture movie = GetComponent<Renderer>().material.GetTexture("_MainTex") as MovieTexture;
		MovieTexture movie2 = GetComponent<Renderer>().material.GetTexture("_AlphaVideo") as MovieTexture;

		movie2.Play ();
		movie.Play ();


	}

	// Update is called once per frame
	void Update () {
	
		}
}
