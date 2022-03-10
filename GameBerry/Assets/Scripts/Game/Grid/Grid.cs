using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public BlockStorage shapeStorage;

    public int coloumns = 0;
    public int rows = 0;
    public float squaresGap = 0.1f;
    public GameObject gridsquare;
    public Vector2 startPosition = new Vector2(0.0f, 0.0f);
    public float squareScale = 0.5f;
    public float everysquareOfset = 0.0f;

    

    private Vector2 _offset = new Vector2(0.0f, 0.0f);
    private List<GameObject> _gridSquares = new List<GameObject>();


    void Start()
    {
        createGrid();
    }

    private void OnEnable()
    {
        GameEvents.CheckIfShapeCanBePlaced +=CheckIfShapeCanBePlaced;

    }
    private void OnDisable()
    {
         GameEvents.CheckIfShapeCanBePlaced -=CheckIfShapeCanBePlaced;

    }

    private void createGrid()
    {
       spawnGridSquares();
       setGridSquarePos();
    }


    private void spawnGridSquares()
    {

        int square_Index= 0;

        for(var row=0; row<rows; ++row)
        {
             for(var coloumn=0; coloumn<coloumns; ++coloumn)
             {
                 _gridSquares.Add(Instantiate(gridsquare) as GameObject);
                 _gridSquares[_gridSquares.Count-1].GetComponent<GridSquare>().SquareIndex = square_Index;
                 _gridSquares[_gridSquares.Count-1].transform.SetParent(this.transform);
                 _gridSquares[_gridSquares.Count-1].transform.localScale = new Vector3(squareScale,squareScale,squareScale);
                 _gridSquares[_gridSquares.Count-1].GetComponent<GridSquare>().SetImage(square_Index % 2==0);
                 square_Index++;
             }         

        }



    }
    private void setGridSquarePos()
    {
        int coloumn_Number=0;
        int row_Number=0;
        Vector2 square_Gap_Number= new Vector2(0.0f,0.0f);
        bool row_Moved=false;

        var square_Rect= _gridSquares[0].GetComponent<RectTransform>();

        _offset.x= square_Rect.rect.width* square_Rect.transform.localScale.x+everysquareOfset;
        _offset.y= square_Rect.rect.height* square_Rect.transform.localScale.y+everysquareOfset;

        foreach ( GameObject square in _gridSquares)
        {
            if(coloumn_Number+1 > coloumns)
            {
                square_Gap_Number.x=0;
                
                coloumn_Number =0;
                row_Number++;
                row_Moved=false;
            }

            var pos_x_offset = _offset.x * coloumn_Number + (square_Gap_Number.x * squaresGap);
            var pos_y_offset=  _offset.y * row_Number+ (square_Gap_Number.y * squaresGap);

            if(coloumn_Number>0 && coloumn_Number % 3==0)
            {
                square_Gap_Number.x++;
                pos_x_offset+=squaresGap;
            }

            if(row_Number>0 && row_Number % 3 ==0 && row_Moved==false)
            {
                row_Moved=true;
                square_Gap_Number.y++;
                pos_y_offset+= squaresGap;

            }

            square.GetComponent<RectTransform>().anchoredPosition = new Vector2(startPosition.x+pos_x_offset, startPosition.y-pos_y_offset);
            square.GetComponent<RectTransform>().localPosition= new Vector3(startPosition.x+pos_x_offset, startPosition.y-pos_y_offset,0.0f);
            coloumn_Number++;
        }

    }

    private void CheckIfShapeCanBePlaced()
    {
        var squreIndexes = new List<int>();
         foreach (var square in _gridSquares)
         {
             var gridSquare = square.GetComponent<GridSquare>();
             
             if(gridSquare.Selected && !gridSquare.SquareOccupied)
             {
                 squreIndexes.Add(gridSquare.SquareIndex);
                 gridSquare.Selected=false;


                 //gridSquare.ActivateSquare();
             }

         }
          var currentSelectedShape = shapeStorage.GetCurrentSelectedShape();
          if(currentSelectedShape == null)
          {
              return;
          }

          if(currentSelectedShape.totalSquareNumber == squreIndexes.Count)
          {
              foreach (var squrIndexe in squreIndexes)
              {
                  _gridSquares[squrIndexe].GetComponent<GridSquare>().placeShapeOnBoard();                  
              }

              var shapeLeft =0;

              foreach (var shape in shapeStorage.shapeList)
              {
                  if(shape.isOnStartPos() && shape.isAnyOfShapeSquareActive() )
                  {
                      shapeLeft++;
                  }
                  
              }
             // currentSelectedShape.DeActivateShape();

              if(shapeLeft == 0)
              {
                  GameEvents.RequestNewShapes();

              }

              else
              {
                  GameEvents.SetShapeInActive();
              }

            
              
          }

          else // Cannot Place Block on the board
          {
              GameEvents.MoveShapeToStartPosition();

          }

         
    }
   
}
