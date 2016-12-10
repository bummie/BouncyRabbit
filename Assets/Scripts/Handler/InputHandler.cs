using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {


    // Playerobject
    public GameObject player;

    public float maxVelocity = 15f, dampValue = 0.3f;
    private float curYVel = 0.0f;

    public float maxHeight = 9f, dampValueHeightLimit = 0.05f;

	void Start ()
    {
	    
	}
	
	void Update ()
    {
        // Dytte katten ned når den når for høyt
        if (player.transform.position.y >= maxHeight)
        {
            float newYVel = Mathf.SmoothDamp(player.GetComponent<Rigidbody2D>().velocity.y, -1f, ref curYVel, dampValueHeightLimit);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, newYVel);
        }

        // Når trykker space
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            player.GetComponent<Animator>().SetBool("isFalling", true);
            float newYVel = Mathf.SmoothDamp(player.GetComponent<Rigidbody2D>().velocity.y, -maxVelocity, ref curYVel, dampValue);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, newYVel);
          
        }

        // Når slipper space
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            player.GetComponent<Animator>().SetBool("isFalling", false);
        }
    }

    
}
