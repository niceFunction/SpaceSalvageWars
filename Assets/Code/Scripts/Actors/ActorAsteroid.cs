using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorAsteroid : Actor
{
    public enum AsteroidSize { SMALL, MEDIUM, BIG }
    public AsteroidSize size = AsteroidSize.BIG;

    public GameObject collectibleObjectDrop;
}
