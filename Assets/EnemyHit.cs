using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RigidbodyConstraints2D con = RigidbodyConstraints2D.None;
            other.GetComponent<Rigidbody2D>().constraints = con;
            transform.parent.GetComponent<Rigidbody2D>().constraints = con;
            // transform.parent.GetComponent<MoveEnemy>().velocity = 0;
            transform.parent.GetComponent<Rigidbody2D>().isKinematic = false;

            other.GetComponent<Player>().isDead = true;
        }
    }
}
