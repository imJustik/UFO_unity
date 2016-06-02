using UnityEngine;
using System.Collections;

public class BoungaryForPlanet : MonoBehaviour {

	 void OnTriggerEnter(Collider other)
    {
    	if (other.tag != "Planet") {
    		return;
    	}
        Destroy(other.gameObject);
        Destroy(gameObject);
        //Debug.Log(other.tag);
    }

}