using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class HighScore
{
    public int score =0;
}

public class Scores : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject popScoreText;
    public GameObject highScoreText;
    public GameObject popHighScoreText;

    private bool newBestScore =false;
    private HighScore _highScore = new HighScore();
    private int _score;
    private string HighScoreKey = "HSData";

    void Awake()
    {
        // StartCoroutine(ReadDataFile());
        if(BinaryData.Exists(HighScoreKey))
        {
            StartCoroutine(ReadDataFile());
        }
        
    }

    private IEnumerator ReadDataFile()
    {
        _highScore = BinaryData.Read<HighScore>(HighScoreKey);
        yield return  new WaitForEndOfFrame();

        Debug.Log(_highScore.score);
    }
    
    



    void Start()
    {
         newBestScore =false;
        _score=0;
          UpdateScoreText();

    }

   

    public void OnEnable()
    {
        GameEvents.AddScore+= AddScore;
        GameEvents.GameOver+= SaveScore;

    }
    public void OnDisable()
    {
         GameEvents.AddScore-= AddScore;
        GameEvents.GameOver-= SaveScore;

    }

    private void SaveScore(bool newBestScore)
    {
        BinaryData.Save<HighScore>(_highScore,HighScoreKey);
    }

    private void AddScore(int score)
    {

        _score +=score;
        if(_score > _highScore.score)
        {
            newBestScore =true;
            _highScore.score = _score;
            
        }
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text= _score.ToString();
        popScoreText.GetComponent<Text>().text= _score.ToString();
        highScoreText.GetComponent<TMPro.TextMeshProUGUI>().text= _highScore.score.ToString();
        popHighScoreText.GetComponent<Text>().text=_highScore.score.ToString();
    }

   
    
}
