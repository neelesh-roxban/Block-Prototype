using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scores : MonoBehaviour
{
    public GameObject scoreText;
    private int _score;


     void Start()
    {
        _score=0;
          UpdateScoreText();

    }

    public void OnEnable()
    {
        GameEvents.AddScore+= AddScore;

    }
    public void OnDisable()
    {
         GameEvents.AddScore-= AddScore;

    }

    private void AddScore(int score)
    {

        _score +=score;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text= _score.ToString();
    }

   
    
}
