using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineIndicater : MonoBehaviour
{
    public int[,] lineData = new int[10,9]
    {
        {0, 1, 2, 3, 4, 5, 6, 7, 8},
        {9, 10,11,12,13,14,15,16,17},
        {18,19,20,21,22,23,24,25,26},
        {27,28,29,30,31,32,33,34,35},
        {36,37,38,39,40,41,42,43,44},
        {45,46,47,48,49,50,51,52,53},
        {54,55,56,57,58,59,60,61,62},
        {63,64,65,66,67,68,69,70,71},
        {72,73,74,75,76,77,78,79,80},
        {82,82,83,84,85,86,87,88,89}
    };
  
  public int[,] squareData = new int[10,9]
  {
       
        {0, 1, 2, 3, 4, 5, 6, 7, 8},
        {9, 10,11,12,13,14,15,16,17},
        {18,19,20,21,22,23,24,25,26},
        {27,28,29,30,31,32,33,34,35},
        {36,37,38,39,40,41,42,43,44},
        {45,46,47,48,49,50,51,52,53},
        {54,55,56,57,58,59,60,61,62},
        {63,64,65,66,67,68,69,70,71},
        {72,73,74,75,76,77,78,79,80},
        {82,82,83,84,85,86,87,88,89}
    };

    [HideInInspector]
    public int[] columnIndexs = new int[9]
    {
        0,1,2,3,4,5,6,7,8
    };

    private (int, int) GetSquarePosition(int square_Index)
    {
        int pos_row =-1;
        int pos_col = -1;

        for (int row=0; row<10; row++)
        {
            for (int col =0; col<9; col++)
            {
                if(lineData[row,col]==square_Index)
                {
                    pos_row = row;
                    pos_col = col;
                }

            }
        }

        return (pos_row, pos_col);
    }

    public int[] GetVerticalLine(int square_Index)
    {
        //columns
        int[] line = new int[10];  // Maybe 10 not 9
        var square_Position_col = GetSquarePosition(square_Index).Item2;
        //

        for (int index=0; index<10; index++) // Maybe 10 not 9
        {
            line[index] = lineData[index, square_Position_col];
        }

        return line;


    }
  

  public int GetGridSquareIndex( int square)
  {
      for (int row=0; row<10; row++)
      {
          for (int col=0; col<9; col++)
          {
              if(squareData[row,col]==square)
              {
                  return row;
              }
          }
      }

      return -1;
      
       
  }

}
