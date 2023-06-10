using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementButton : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject anakarakter;
    public bool isWalkingLeft=false;
    public bool isWalkingRight=false;
   
    void Update()
    {
        if (isWalkingLeft)
        {
            if (anakarakter.transform.position.z> -89.64)
            {
            anakarakter.transform.position += new Vector3(0, 0, -speed);

            }
            
        }
        if (isWalkingRight)
        {
            if (anakarakter.transform.position.z< -77.437)
            {
            anakarakter.transform.position += new Vector3(0, 0, speed);
            }
            
        }
    }
    public void isTriggerLeft(bool CanMoveLeft)
    {
        isWalkingLeft=CanMoveLeft;
    }
    public void isTriggerRight(bool CanMoveRight)
    { isWalkingRight=CanMoveRight;}
}
