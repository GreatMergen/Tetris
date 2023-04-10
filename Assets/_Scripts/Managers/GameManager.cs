using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance;
  public float GameSpeed => gameSpeed;
  [SerializeField, Range(0f, 1f)] private float gameSpeed = 1f;
  private void Awake() => Instance = this;
}
