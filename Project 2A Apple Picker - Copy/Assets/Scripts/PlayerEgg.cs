using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Deletes Egg when it hits player
/// </summary>
public class PlayerEgg : MonoBehaviour
{
    ////variables
    public Text text;
    public static int count = 0;
    public AudioSource Sfx;

    //enemy prefab collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EGG")
        {
            Destroy(collision.gameObject);
            count += 20;
            //update text
            text.text = "Points: " + count;
            //sfx
            Sfx.Play();
        }
    }
}
