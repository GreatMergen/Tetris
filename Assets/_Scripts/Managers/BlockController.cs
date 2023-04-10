using System;
using System.Collections;
using UnityEngine;


public class BlockController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(MoveDown());
    }

   private  IEnumerator MoveDown()
       {
           while (true)
           {
               var delay = GameManager.Instance.GameSpeed;
               yield return new WaitForSeconds(delay);
               var pos = transform.position;
               pos.y--;
               transform.position = pos;
           }
       }
}
