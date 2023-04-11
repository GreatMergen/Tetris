using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject[] tetrisBlocks;

    public static Spawner Instance;

    private void Awake() => Instance = this;

    void Start()
    {
        SpawnNewBlock();
    }


    public void SpawnNewBlock()
    {
        Instantiate(tetrisBlocks[Random.Range(0, tetrisBlocks.Length)], transform.position, Quaternion.identity);
    }
}
