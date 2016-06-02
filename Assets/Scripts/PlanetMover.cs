using UnityEngine;
using System.Collections;
public class PlanetMover : MonoBehaviour 
{
	public float speedByX;
	public float speedSin;
	public float amplituda;
	private float test;

	private Vector3 _startPosition;
	private Vector3 mov;

	void Start () 
	{
		_startPosition = transform.position;
		mov = new Vector3(0,0,0);
		test = 0;
	}

	void Update()
 	{
   
            test = test + 0.025f;
            mov = _startPosition + new Vector3(-test * speedByX, 0.0f, amplituda * Mathf.Sin(test * speedSin));
            transform.position = mov;

	}
}
