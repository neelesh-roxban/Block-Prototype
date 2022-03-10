using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public int coloumns = 0;
    public int rows = 0;
    public float squaresGap = 0.1f;
    public GameObject gridsquare;
    public Vector2 startPosition = new Vector2(0.0f, 0.0f);
    public float squareScale = 0.5f;
    public float everysquareOfset = 0.0f;


    private Vector2 offset = new Vector2(0.0f, 0.0f);
    private List<GameObject> gameObjects = new List<GameObject>();



    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
