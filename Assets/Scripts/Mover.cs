﻿using UnityEngine;
using System.Collections;
public class Mover : MonoBehaviour 
{
	public float speed;

	void Start () 
	{
		GetComponent<Rigidbody>().velocity = transform.right * (speed-(Time.time/9));
	}

}
