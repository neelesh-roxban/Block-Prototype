﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static Action CheckIfShapeCanBePlaced;
    public static Action MoveShapeToStartPosition;
    public static Action RequestNewShapes;
    public static Action SetShapeInActive;
    public static Action<int> AddScore; 
    public static Action<bool> GameOver; 
   


}
