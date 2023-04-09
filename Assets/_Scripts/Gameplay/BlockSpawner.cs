using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;



public class BlockSpawner : MonoBehaviour
{
    public GameObject[] groups;
    
    void Start() {
        // Spawn initial Group
        spawnNext();
    }
    
    public void spawnNext() 
    {
        // Random Index
        int i = UnityEngine.Random.Range(0, groups.Length);

        // Spawn Group at current Position
        Instantiate(groups[i], transform.position, Quaternion.identity);
    }
}
