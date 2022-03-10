using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shape : MonoBehaviour, IPointerClickHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
//Block = ShapeDate
    public GameObject squareShapeImage;     
    public Vector3 shapeSelectedScale;
    public Vector2 offset = new Vector2(0f,700f);


    [HideInInspector]
    public Block currentShapeData;

    private List<GameObject> _currentShape = new List<GameObject>();
    private Vector3 _shapeStartScale;
    private RectTransform _transform;
    private bool _shapeDragable = true;
    private Canvas _canvas;

    public void Awake()
    {
        _shapeStartScale = this.GetComponent<RectTransform>().localScale;
        _transform = this.GetComponent<RectTransform>();
        _canvas=GetComponentInParent<Canvas>();
        _shapeDragable= true;

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
                   _currentShape[currentIndexInList].GetComponent<RectTransform>().localPosition= new Vector2(GetXPositionForShapeSquare(block,coloumn,moveDistance),  GetYPositionForShapeSquare(block, row, moveDistance));
                   currentIndexInList++;
               }
            }
        }
    }



   
    private float GetYPositionForShapeSquare(Block shapeData, int row, Vector2 moveDistance)
    {
        float shiftOnY = 0f;
        if (shapeData.rows > 1)
        {
            float startYPos;
            if (shapeData.rows % 2 != 0)
                startYPos = (shapeData.rows / 2) * moveDistance.y;
            else
                startYPos = ((shapeData.rows / 2) - 1) * moveDistance.y + moveDistance.y / 2;
            shiftOnY = startYPos - row * moveDistance.y;
        }
        return shiftOnY;
    }


   private float GetXPositionForShapeSquare(Block shapeData, int column, Vector2 moveDistance)
    {
        float shiftOnX = 0f;
        if (shapeData.coloumns > 1)
        {
            float startXPos;
            if (shapeData.coloumns % 2 != 0)
                startXPos = (shapeData.coloumns / 2) * moveDistance.x * -1;
            else
                startXPos = ((shapeData.coloumns / 2) - 1) * moveDistance.x * -1 - moveDistance.x / 2;
            shiftOnX = startXPos + column * moveDistance.x;

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

    
    public  void OnPointerClick(PointerEventData eventData)
    {

    
    }
    public   void OnPointerUp(PointerEventData eventData)
    {

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale=shapeSelectedScale;

    }
    public  void OnDrag(PointerEventData eventData)
    {
        _transform.anchorMin= new Vector2(0,0);
        _transform.anchorMax = new Vector2(0,0);
        _transform.pivot = new Vector2(0,0);

        Vector2 popsition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, eventData.position, Camera.main, out popsition);
        _transform.localPosition = popsition + offset;

    }
    public  void OnEndDrag(PointerEventData eventData)
    {
         this.GetComponent<RectTransform>().localScale = _shapeStartScale;
    }

    public  void OnPointerDown(PointerEventData eventData)
    {

    }




   


  

}
