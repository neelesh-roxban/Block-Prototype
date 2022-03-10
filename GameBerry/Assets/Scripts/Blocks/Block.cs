using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Block : ScriptableObject
{

    [System.Serializable]
    public class Row
    {
        public bool[] coloumn;
        private int _size=0;

        public Row()
        {

        }

        public Row(int size)
        {
           CreateRow(size);
        }

        public void CreateRow(int size)
        {
            _size= size;
            coloumn= new bool[_size];
            ClearRow();
        }

        public void ClearRow()
        {
            for ( int i =0; i <_size; i++)
            {
                coloumn[i]=false;
            }
        }


    }
    
    public int coloumns=0;
    public int rows=0;
    public Row[] board;

    public void clear()
    {
        for (var i=0; i<rows; i++)
        {
            board[i].ClearRow();
        }
    }

    public void CreateNewBoard()
    {
        board= new Row[rows];

        for(int i=0; i<rows; i++)
        {
            board[i]= new Row(coloumns);
        }
    }
}
