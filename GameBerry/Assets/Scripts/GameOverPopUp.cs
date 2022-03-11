using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPopUp : MonoBehaviour
{
    public GameObject gameOverPopUp;
 //   public GameObject losePopUp;
  //  public GameObject newBeseScorePopUp;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPopUp.SetActive(false);
        
    }


    public void OnEnable()
    {
        GameEvents.GameOver += OnGameOver;

    }

    public void OnDisable()
    {
         GameEvents.GameOver -= OnGameOver;

    }

    private void OnGameOver(bool newBestScore)
    {
        gameOverPopUp.SetActive(true);
        

    }

    
}
