using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class spanobjects : MonoBehaviour
{
    private Rigidbody2D rb;
    //variables for asteriods
    [SerializeField] private GameObject[] asteroidprefabs;
    [SerializeField]private Transform spanX;
    [SerializeField]private Transform span_X;
    [SerializeField]private float asteroidspantime = 0.3f;
    private int asteroidindex;

    //variables for planets
    [SerializeField] private GameObject[] planets;
    [SerializeField]private float planetspantime = 8.0f;
    private int planetindex;

    //variables for enemyships
    [SerializeField] private GameObject[] enemyships;
    [SerializeField] private float enemyspantime = 3.0f;
    private int enemyshipindex;

    //fuel station
    [SerializeField] private GameObject fuelstation;
    [SerializeField] private float fuelstationspantime = 10.0f;

    //variables for debrises
    [SerializeField] private GameObject[] particleprefab;
    [SerializeField] private float particlespantime = 3.0f;
    private int particleindex;

    void Start()
    {
        StartCoroutine(spawnasteroids());
        StartCoroutine(spawnplanets());
        StartCoroutine(spawnenemyships());
        StartCoroutine(spawnfuelstations());
        StartCoroutine(spawnparticles());
    }
    //spawning the particles
    private void spawnparticle()
    {
        particleindex = Random.Range(0, (particleprefab.Length - 1));
        GameObject particle = Instantiate(particleprefab[particleindex]) as GameObject;
        particle.transform.position = new Vector2(Random.Range(span_X.position.x+5, spanX.position.x-5), spanX.position.y+20);
    }
    IEnumerator spawnparticles()
    {
        while (true)
        {
            yield return new WaitForSeconds(particlespantime);
            spawnparticle();
        }
    }
    //spawning the fuel stations
    private void spawnfuelstation()
    {
        GameObject station = Instantiate(fuelstation) as GameObject;
        station.transform.position = new Vector2(Random.Range(span_X.position.x+10, spanX.position.x-10), spanX.position.y+15f);
        
    }
    IEnumerator spawnfuelstations()
    {
        while (true)
        {
            yield return new WaitForSeconds(fuelstationspantime);
            spawnfuelstation();
        }
    }

    //spawning the enemyships
    private void spawnenemyship()
    {
        enemyshipindex = Random.Range(0, (enemyships.Length - 1));
        GameObject enemy = Instantiate(enemyships[enemyshipindex]) as GameObject;
        enemy.transform.position = new Vector2(Random.Range(span_X.position.x, spanX.position.x), spanX.position.y);
        //asteroid.transform.rotation
    }
    IEnumerator spawnenemyships()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemyspantime);
            spawnenemyship();
        }
    }
    //spawning the asteroids
    private void spawnasteroid()
    {
        asteroidindex = Random.Range(0, (asteroidprefabs.Length - 1));
        GameObject asteroid = Instantiate(asteroidprefabs[asteroidindex]) as GameObject;
        asteroid.transform.position = new Vector2(Random.Range(span_X.position.x, spanX.position.x), spanX.position.y);
        rb=asteroid.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -2f);
    }
    IEnumerator spawnasteroids()
    {
        while (true)
        {
            yield return new WaitForSeconds(asteroidspantime);
            spawnasteroid();
        }
    }
    //spawning the planets
    private void spawnplanet()
    {
        planetindex = Random.Range(0, (planets.Length - 1));
        GameObject planet = Instantiate(planets[planetindex]) as GameObject;
        planet.transform.position = new Vector2(Random.Range(span_X.position.x - 5, spanX.position.x + 5), spanX.position.y + 20);
        
    }
    IEnumerator spawnplanets()
    {
        while (true)
        {
            yield return new WaitForSeconds(planetspantime);
            spawnplanet();
        }
    }
}
