﻿using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
	public int time; 
	// Use this for initialization
	void Start () {
		Destroy(gameObject, time);
	}
	
	
}
