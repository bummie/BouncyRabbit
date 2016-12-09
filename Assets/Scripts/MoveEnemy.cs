using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {

    public float velocity = 2f;
	void Start ()
    {
	
	}
	
	void Update ()
    {
        if (transform.position.x <= -12f)
            Destroy(gameObject);
        GetComponent<Rigidbody2D>().velocity = new Vector2(-velocity, 0);
	}
}
