using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubeSpawnerManager : MonoBehaviour
{
    public PlayerBase player1Base;
    public PlayerBase player2Base;
    public PlayerBase player3Base;
    public PlayerBase player4Base;

    public GameObject[] iceCubeSpawners;
    // Start is called before the first frame update
    void Start()
    {

        player1Base.OnPlayerScoreHandler += RandomActivateSpawner;
        player2Base.OnPlayerScoreHandler += RandomActivateSpawner;
        player3Base.OnPlayerScoreHandler += RandomActivateSpawner;
        player4Base.OnPlayerScoreHandler += RandomActivateSpawner;
    }

    public void RandomActivateSpawner(int playerId, int score) // id knows where the playerbase is so perhaps spawn furthest away from player? Or Not... Testing!
    {
        //Deactivate all Spawners

        for (int i = 0; i < iceCubeSpawners.Length; i++)
        {
            iceCubeSpawners[i].SetActive(false);
        }
        //Activate a random spawner

        int _randomSpawner = Random.Range(0, iceCubeSpawners.Length);
        iceCubeSpawners[_randomSpawner].SetActive(true);
    }
}
