using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyContainer;
    public float spawnRateBird = 2f, spawnRateCar = 3f;
    private float timerBird = 0f, timerCar = 0f;
	void Start ()
    {
        
	}
	
	void Update ()
    {
        // Spawn cars and birds
        timerBird += Time.deltaTime;
        timerCar += Time.deltaTime;
        if (timerBird >= spawnRateBird)
        {
            spawnBird(Random.Range(2.5f, 9f), Random.Range(4f, 12f));
            spawnRateBird = (Random.Range(.65f, 1.5f));
            timerBird = 0f;
        }
        if (timerCar >= spawnRateCar)
        {
            spawnCar(Random.Range(5f, 12f));
            spawnRateCar = (Random.Range(2f, 3f));
            timerCar = 0f;
        }
    }


    public void spawnBird(float yPos, float velocity)
    {
        GameObject bird = (GameObject)Instantiate(Resources.Load("Prefabs/Bird"));
        bird.transform.position = new Vector3(12f, yPos, 0f);
        bird.transform.parent = EnemyContainer.transform;
        bird.name = "Bird";
        bird.GetComponent<MoveEnemy>().velocity = velocity;
    }

    public void spawnCar(float velocity)
    {
        GameObject bird = (GameObject)Instantiate(Resources.Load("Prefabs/Car"));
        bird.transform.position = new Vector3(12f, 1.7f, 0f);
        bird.transform.parent = EnemyContainer.transform;
        bird.name = "Car";
        bird.GetComponent<MoveEnemy>().velocity = velocity;
    }
}
