using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Woolpy")
        {
            Destroy(other.gameObject);
        }
    }
}
