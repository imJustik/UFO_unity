using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    public float tumble;
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = transform.up * tumble;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
