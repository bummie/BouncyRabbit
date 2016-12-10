using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public bool isDead = false;

    private bool soundPlayed = false;

    void Update()
    {
        if (GetComponent<Rigidbody2D>().velocity.y < 0)
            soundPlayed = false;

        if(!soundPlayed && GetComponent<Rigidbody2D>().velocity.y >= 0)
        {
            if (!GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().Play();

            soundPlayed = true;
        }
    }
}
