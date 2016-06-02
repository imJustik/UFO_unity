using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Vector3 leftUp;
    public Vector3 leftDown;
    public Vector3 rightUp;
    public Vector3 rightDown;

    public float stepRate;

    private Vector3[] moveCoords;
    private Vector3 thisPosition;

    private int lastPosition;
    private float nextStep = 0;

    private Animator animator;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }


    void Start () 
    {
        lastPosition = 0;
        moveCoords = new Vector3[]{ leftUp, rightUp, rightDown, leftDown };
    }

    void Update () {
        thisPosition = moveCoords [lastPosition]; 
        
        if (Input.GetButtonDown ("Fire1") && Time.time > nextStep )
        {
            nextStep = stepRate + Time.time;


            if (lastPosition == 3)
            {
                lastPosition = 0;
            }
            else
            {
                lastPosition++;
            }
           
            
        }

        animator.SetInteger("Rotate", lastPosition);

    }
        
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards (transform.position, thisPosition, stepRate);       
    }

        
}