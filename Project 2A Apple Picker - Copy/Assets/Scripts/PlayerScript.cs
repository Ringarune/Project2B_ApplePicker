using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls player sprite position and movement inputs
/// </summary>
public class PlayerScript : MonoBehaviour
{
    //variables
    public float speed = 75;
    public float LeftandRightEdge;
    private bool StartMovement = false;

    // Update is called once per frame
    void Update()
    {
        //no movement until player input
        if (Input.GetMouseButton(0))
        {
            StartMovement = true;
        }

        //updates start when mouse click is registered
        if (StartMovement)
        {
            Vector3 pos = transform.position;

            //Player Movement
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed = 75;
                //Makes sure sprite doesn't pass edge
                if (pos.x < LeftandRightEdge)
                {
                    pos.x += speed * Time.deltaTime;
                    transform.position = pos;
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed = -75;
                //Makes sure sprite doesn't pass edge
                if (pos.x > -LeftandRightEdge)
                {
                    pos.x += speed * Time.deltaTime;
                    transform.position = pos;
                }
            }
        }
    }
}
