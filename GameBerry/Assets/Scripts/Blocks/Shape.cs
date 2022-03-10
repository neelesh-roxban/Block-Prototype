using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
//Block = ShapeDate
    public GameObject squareShapeImage;     
    //[HideInInspector]
    public Block currentShapeData;
    private List<GameObject> _currentShape = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        RequestNewShape(currentShapeData);
        //
    }

    public void RequestNewShape(Block block)
    {
        CreateBlock(block);
    }


    public void CreateBlock(Block block)
    {
        currentShapeData = block;
        var totalSquareNumber = getNumberOfSquares(block);
        while(_currentShape.Count <= totalSquareNumber)
        {
            _currentShape.Add(Instantiate(squareShapeImage,transform) as GameObject);
        }
        foreach (var square in _currentShape)
        {
            square.gameObject.transform.position= Vector3.zero;
            square.gameObject.SetActive(false);
        }
        var squareRect = squareShapeImage.GetComponent<RectTransform>();
        var moveDistance = new Vector2( squareRect.rect.width* squareRect.localScale.x, squareRect.rect.height* squareRect.localScale.y);
        int currentIndexInList = 0;

        for(var row =0; row<block.rows; row++)
        {
            for (var coloumn=0; coloumn<block.coloumns; coloumn++)
            {
               if( block.board[row].coloumn[coloumn])
               {
                   _currentShape[currentIndexInList].SetActive(true);
                   _currentShape[currentIndexInList].GetComponent<RectTransform>().localPosition= new Vector2(getXPositionFroShapeSquare(block,coloumn,moveDistance), getYPositionForShapeSquare(block, row, moveDistance));
                   currentIndexInList++;
               }
            }
        }
    }



    private float getYPositionForShapeSquare(Block block, int row, Vector2 moveDistance)
    {
        float shiftOnY = 0f;
        if(block.rows>1)
        {
            if(block.rows % 2  !=0)
            {
                var middleSquareIndex= (block.rows-1)/2 ;
                var multiplier = (block.rows-1)/2;
                if(row<middleSquareIndex)
                {
                    shiftOnY = moveDistance.y*-1;
                    shiftOnY*= multiplier;
                }
                else if(row > middleSquareIndex)
                {
                    shiftOnY = moveDistance.y* 1;
                    shiftOnY*= multiplier;
                }
            }

            else
            {
                var middleSquareIndex2 = (block.rows ==2) ? 1 : (block.rows/2);
                var middleSquareIndex1 = (block.rows ==2) ? 0 : (block.rows-1);
                var multiplier = block.rows/2;

                if( row== middleSquareIndex1|| row == middleSquareIndex2)
                {
                    if(row==middleSquareIndex2)
                    {
                         shiftOnY = (moveDistance.y/2)*-1;
                    }

                    if(row==middleSquareIndex1)
                    {
                        shiftOnY = (moveDistance.y/2);
                    }
                }

                 if(row<middleSquareIndex1 && row < middleSquareIndex2)
                {
                    shiftOnY = moveDistance.y * 1;
                    shiftOnY *= multiplier;
                }
                else
                if( row > middleSquareIndex1 && row > middleSquareIndex2)
                {
                    shiftOnY = moveDistance.y * -1;
                    shiftOnY *= multiplier;
                }

                
            }
        }

        return shiftOnY;
    }


    private float getXPositionFroShapeSquare(Block block, int coloumn, Vector2 moveDistance)
    {
        float shiftOnX= 0f;

        if(block.coloumns>1)
        {
            if(block.coloumns % 2  !=0)
            {
                var middleSquareIndex= (block.coloumns-1)/2 ;
                var multiplier = (block.coloumns-1)/2;
                if(coloumn<middleSquareIndex)
                {
                    shiftOnX = moveDistance.x*-1;
                    shiftOnX*= multiplier;
                }
                else if(coloumn > middleSquareIndex)
                {
                    shiftOnX = moveDistance.x* 1;
                    shiftOnX*= multiplier;
                }
            }

            else
            {
                var middleSquareIndex2 = (block.coloumns ==2) ? 1 : (block.coloumns/2);
                var middleSquareIndex1 = (block.coloumns ==2) ? 0 : (block.coloumns-1);
                var multiplier = block.coloumns/2;

                if( coloumn== middleSquareIndex1|| coloumn == middleSquareIndex2)
                {
                    if(coloumn==middleSquareIndex2)
                    {
                        shiftOnX = moveDistance.x/2;
                    }

                    if(coloumn==middleSquareIndex1)
                    {
                        shiftOnX = (moveDistance.x/2)*-1;
                    }
                }

                if(coloumn<middleSquareIndex1 && coloumn < middleSquareIndex2)
                {
                    shiftOnX = moveDistance.x * -1;
                    shiftOnX *= multiplier;
                }
                else
                {
                    shiftOnX = moveDistance.x * 1;
                    shiftOnX *= multiplier;
                }

            }
        }

        return shiftOnX;
        


    }

    private int getNumberOfSquares(Block block)
    {
        int number =0;
         foreach (var rowData in block.board)
         {

             foreach (var active in rowData.coloumn)
             {
                 if (active)
                 {
                     number++;
                 }

                 
             }
             
         }

         return number;
    }

  
}
