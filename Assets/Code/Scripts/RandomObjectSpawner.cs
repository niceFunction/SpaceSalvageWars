using System.Collections;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public bool isAsteroidSpawner = true;

    public bool infiniteTimerLoop = true;
    public bool isOneShot = false;


    public Vector2 randomTimeBetweenSpawnMinMax = new Vector2(1, 5);
    public Vector2 randomObjectSpawnOffsetMinMaxX = new Vector2(-1, 1);
    public Vector2 randomObjectSpawnOffsetMinMaxY = new Vector2(-1, 1);

    public GameObject[] objectsToSpawn;
    public int amountOfObjectsToSpawn;
    public bool spawnObjectsIntoContainer = true;
    public Transform objectsSpawnerContainer;

    private int _currentObjectsSpawned;
    private Transform _transform;

    public bool isRandomAddForceOnEntrance = true;
    public Vector2 randomAddForceEntranceMinMaxX;
    public Vector2 randomAddForceEntranceMinMaxY;


    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        if(objectsToSpawn == null)
        {
            return;
        }
        StartCoroutine("SpawnTimer");
    }
    void OnEnable()
    {
        if (objectsToSpawn == null)
        {
            return;
        }
        StartCoroutine("SpawnTimer");
    }

    private IEnumerator SpawnTimer()
    {
        float normalizedTime = 0;
        float spawnTime = UnityEngine.Random.Range(randomTimeBetweenSpawnMinMax.x, randomTimeBetweenSpawnMinMax.y);
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / spawnTime;
            yield return null;
        }
        if (_currentObjectsSpawned < amountOfObjectsToSpawn)
        {
            if (isOneShot)
            {
                for (int i = 0; i < amountOfObjectsToSpawn; i++)
                {
                    if (spawnObjectsIntoContainer)
                    {
                        SpawnObjectIntoContainer();
                    }
                    else
                    {
                        SpawnObject();
                    }
                }
            }
            else
            {
                if (spawnObjectsIntoContainer)
                {
                    SpawnObjectIntoContainer();
                }
                else
                {
                    SpawnObject();
                }
            }
        }
        else
        {
            if (isOneShot)
            {
                Destroy(this); // Destroy this component when all objects spawned, STOP LOOP
            }
        }
        if (infiniteTimerLoop)
        {
            if (spawnObjectsIntoContainer)
            {
                _currentObjectsSpawned = objectsSpawnerContainer.childCount;
            }
            StartCoroutine("SpawnTimer"); // TIMER RESTART LOOP
        }
    }

    private void SpawnObjectIntoContainer()
    {
        //Pick Random Object To Spawn from objectsToSpawn Array
        GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

        var spawnObjectInstance = Instantiate(objectToSpawn, objectsSpawnerContainer.position,objectsSpawnerContainer.rotation,objectsSpawnerContainer);
        float newRandomOffsetX = UnityEngine.Random.Range(randomObjectSpawnOffsetMinMaxX.x, randomObjectSpawnOffsetMinMaxX.y);
        float newRandomOffsetY = UnityEngine.Random.Range(randomObjectSpawnOffsetMinMaxY.x, randomObjectSpawnOffsetMinMaxY.y);
        spawnObjectInstance.transform.position = objectsSpawnerContainer.position + new Vector3(newRandomOffsetX, newRandomOffsetY, 0);

        if (isAsteroidSpawner && isRandomAddForceOnEntrance)
        {
            spawnObjectInstance.GetComponent<ActorAsteroid>().body.AddForce(new Vector2(Random.Range(randomAddForceEntranceMinMaxX.x, randomAddForceEntranceMinMaxX.y),
                                                                                        Random.Range(randomAddForceEntranceMinMaxY.x, randomAddForceEntranceMinMaxY.y)));
        }
        
        _currentObjectsSpawned = objectsSpawnerContainer.childCount;

        if (isOneShot)
        {
            return;
        }
        else
        {
            StartCoroutine("SpawnTimer");
        }
    }

    private void SpawnObject()
    {
        //Pick Random Object To Spawn from objectsToSpawn Array
        GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

        var spawnObjectInstance = Instantiate(objectToSpawn, _transform.position, _transform.rotation);
        float newRandomOffsetX = UnityEngine.Random.Range(randomObjectSpawnOffsetMinMaxX.x, randomObjectSpawnOffsetMinMaxX.y);
        float newRandomOffsetY = UnityEngine.Random.Range(randomObjectSpawnOffsetMinMaxY.x, randomObjectSpawnOffsetMinMaxY.y);
        spawnObjectInstance.transform.position = objectsSpawnerContainer.position + new Vector3(newRandomOffsetX, newRandomOffsetY, 0);

        if(_currentObjectsSpawned < amountOfObjectsToSpawn)
        {
            _currentObjectsSpawned += 1;
        }

        if (isOneShot)
        {
            return;
        }
        else
        {
            StartCoroutine("SpawnTimer");
        }
    }


}
