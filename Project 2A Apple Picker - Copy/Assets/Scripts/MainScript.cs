using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

/// <summary>
/// updates the movements of the bunny sprite to move randomly
/// </summary>
public class MainScript : MonoBehaviour
{
    //bunny variables
    [Header("")]
    public GameObject BunnySprite;
    public float directionchangechance = 0.05f;
    public float speed;
    public float LeftandRightEdge = 7.1f;
    private bool StartMovement = false;
    private bool InvokeEgg = false;

    //prefab variables
    [Header ("Prefab")]
    public GameObject prefab;

    //spawns prefab
    public void SpawnObject()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    //starts prefab fall
    void InvokeStart ()
    {
        //prefab spawn
        InvokeRepeating("SpawnObject", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        //Bunny Object Movements
        //no movement until player input
        if (Input.GetMouseButton(0))
        {
            StartMovement = true;
        }

        //starts invokestart function
        if (StartMovement && !InvokeEgg)
        {
            InvokeStart();
            InvokeEgg = true;
        }

        //if mouse button is clicked start updates
        if (StartMovement)
        {
            //random speed
            if (speed < 1)
            {
                speed = Random.Range(-30, -100);
            }
            else
            {
                speed = Random.Range(30, 100);
            }

            //direction change
            if (Random.value <= directionchangechance)
            {
                speed *= -1;
            }

            Vector3 pos = transform.position;

            //making sure bunny sprite stays within boundary

            if (pos.x < -LeftandRightEdge)
            {
                speed = Mathf.Abs(speed);
            }
            else if (pos.x > LeftandRightEdge)
            {
                speed *= -1;
            }

            //movement of bunny
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
        }
    }
}
