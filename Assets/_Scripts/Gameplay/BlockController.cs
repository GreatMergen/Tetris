using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{

    public GameObject currentBlock;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentBlock.transform.position+= Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentBlock.transform.position+= Vector3.left;
        }
        
        currentBlock.transform.position += Vector3.down;
    }
}
