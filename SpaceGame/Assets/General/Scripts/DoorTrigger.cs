using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Vector3 endPos;
    public float speed = 1.0f;

    private bool moving = false;
    private bool opening = true;
    private Vector3 startPos;
    private float delay = 0.0f ;


    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {
        if (moving)
        {
            if (opening)
            {
                MoveDoor(endPos);
            }
            else
            {
                MoveDoor(startPos);
            }
        }


    }

    void MoveDoor(Vector3 goalpos)
    {
        float dist = Vector3.Distance(transform.position, goalpos);
        if(dist > .1f)
        {
            transform.position = Vector3.Lerp(transform.position, goalpos, speed * Time.deltaTime);
        }
        else
        {
            if (opening)
            {
                delay += Time.deltaTime;
                if(delay > 3f)
                {
                opening = false;
                }
            }
            else
            {
                moving = false;
                opening = true;
            }
        }
    }

    public bool Moving
    {
        get { return moving; }
        set { moving = value; }
    }
}
 