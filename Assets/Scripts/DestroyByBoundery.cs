using UnityEngine;
using System.Collections;

public class DestroyByBoundery : MonoBehaviour {

	 void OnTriggerExit(Collider other)
    {
    	// if (other.tag == "Planet") {
    	// 	return;
    	// }
        Destroy(other.gameObject);
        //Debug.Log(other.tag);
    }
}