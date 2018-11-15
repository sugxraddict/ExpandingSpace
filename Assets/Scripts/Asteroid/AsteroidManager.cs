using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour {
    [SerializeField] Asteroid asteroidPrefab;
    [SerializeField] GameObject pickupPrefab;
    [SerializeField] GameObject healthPrefab;
    [SerializeField]int numberOfAsteroidsOnAnAxis = 10;
    [SerializeField]int gridSpacing = 100;


    public List<Asteroid> asteroid = new List<Asteroid>();


    void Start()
    {
        //PlaceAsteroids();
    }


    void OnEnable()
    {
        EventManager.onStartGame += PlaceAsteroids;
        EventManager.onPlayerDeath += DestroyAsteroids;
        EventManager.onRespawnPickup += PlacePickup;
        EventManager.onRespawnPickup += HealthPickup;
    }


    void OnDisable()
    {
        EventManager.onStartGame -= PlaceAsteroids;
        EventManager.onPlayerDeath -= DestroyAsteroids;
        EventManager.onRespawnPickup -= PlacePickup;
        EventManager.onRespawnPickup -= HealthPickup;
    }

    void PlaceAsteroids()
    {
        for(int x = 0; x < numberOfAsteroidsOnAnAxis; x++)
        {
            for (int y = 0; y < numberOfAsteroidsOnAnAxis; y++)
            {
                for (int z = 0; z < numberOfAsteroidsOnAnAxis; z++) 
                {
                    InstantiateAsteroid(x, y, z);
                }
            }
        }

        PlacePickup();
        PlacePickup();
        HealthPickup();
    }


    void DestroyAsteroids()
    {
        foreach(Asteroid ast in asteroid.ToArray())
        {
            ast.SelfDestruct();

            asteroid.Clear();
        }
    }

    void InstantiateAsteroid(int x, int y, int z)
    {
        Asteroid temp = Instantiate(asteroidPrefab, new Vector3(transform.position.x + (x * gridSpacing) + AsteroidOffset(),
             transform.position.y + (y * gridSpacing) + AsteroidOffset(),
             transform.position.z + (z * gridSpacing) + AsteroidOffset()),
             Quaternion.identity,
             transform) as Asteroid;

        temp.name = "Asteroid: " + x + "-" + y + "-" + z;

        asteroid.Add(temp);
    }


    void PlacePickup()
    {
        int rnd = Random.Range(0, asteroid.Count);


        Instantiate(pickupPrefab, asteroid[rnd].transform.position, Quaternion.identity);
        //Debug.Log("Destroying: " + asteroid[rnd].name);
        Destroy(asteroid[rnd].gameObject);
        asteroid.RemoveAt(rnd);
    }

    float AsteroidOffset()
    {
       return Random.Range(-gridSpacing/2f, gridSpacing/2f);
    }

    void HealthPickup()
    {
        int rnd = Random.Range(0, asteroid.Count);


        Instantiate(healthPrefab, asteroid[rnd].transform.position, Quaternion.identity);
        //Debug.Log("Destroying: " + asteroid[rnd].name);
        Destroy(asteroid[rnd].gameObject);
        asteroid.RemoveAt(rnd);
    }

    float HealthAsteroidOffset()
    {
        return Random.Range(-gridSpacing / 2f, gridSpacing / 2f);
    }
}