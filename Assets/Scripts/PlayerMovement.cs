using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject[] MovePoints;

    public int MovementPointCount = 0;

    public float speed;

    public bool TimerActive = false;
    public float InactiveTimer = 8;

    private void OnTriggerEnter(Collider other)
    {
        MovementPointCount += 1;
    }

    // Use this for initialization
    void Start () 
    {
		
	}


    private void Update()
    {
      //  Cam.transform.rotation = mouse;

        if (MovementPointCount >= 98)
        {
            MovementPointCount = 2;
        }
        IsMoving();
    }
    // Update is called once per frame
    void FixedUpdate ()
    {
        Movement();

        if(MovementPointCount >= 99)
        {
            MovementPointCount = 2;
        }

        

    }

    void Movement()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, MovePoints[MovementPointCount].transform.position, step);
    }

    void IsMoving()
    {

        if (TimerActive == true)
        {
            InactiveTimer -= Time.deltaTime; 
        }

        if (InactiveTimer <= 0)
        {
            speed = 4;
            TimerActive = false;
        }

        if (Input.anyKey)
        {
            speed = 0;
            InactiveTimer = 8;
            TimerActive = true;
        }
    }
}
