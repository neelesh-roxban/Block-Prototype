using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShapeSquare : MonoBehaviour
{
  public Image occupideImage;



  void Start()
  {
      occupideImage.gameObject.SetActive(false);
  }

  public void DeActivateShape()
  {
      gameObject.GetComponent<BoxCollider2D>().enabled = false;
      gameObject.SetActive(false);
  }

  public void ActivateShape()
  {
      gameObject.GetComponent<BoxCollider2D>().enabled =true;
       gameObject.SetActive(true);
  }

  public void SetOcupide()
  {
      occupideImage.gameObject.SetActive(true);
  }

  public void UnSetOcupdied()
  {
       occupideImage.gameObject.SetActive(false);
  }
}

