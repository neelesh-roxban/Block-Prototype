﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSquare : MonoBehaviour
{
    public Image normalImage;
    public List<Sprite> normalImages;
    public Image hoverImage;
    public Image activeImage;
    public bool Selected {get; set;}
    public int SquareIndex{get; set;}
    public bool SquareOccupied {get; set;}
    
    void Start()
    {
        Selected = false;
        SquareOccupied = false;
        
    }

   
    public void setImage(bool setFirstImage)
    {
        normalImage.GetComponent<Image>().sprite= setFirstImage? normalImages[1] : normalImages[0];

    }


  
    
     public void OnTriggerEnter2D(Collider2D collision)
    {
        hoverImage.gameObject.SetActive(true);
    }
      public void OnTriggerStay2D(Collider2D collision)
    {
        hoverImage.gameObject.SetActive(true);

    }
     public void OnTriggerExit2D(Collider2D collision)
    {
        hoverImage.gameObject.SetActive(false);
        
    }
}
