using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStorage : MonoBehaviour
{
    public List<Block> block;
     public List<Shape> shapeList;


    void Start()
    {

        foreach (var shape in shapeList)
        {
            var shapeIndex = UnityEngine.Random.Range(0, block.Count);
            shape.CreateBlock(block[shapeIndex]);
            
        }
        
    }

  
}
