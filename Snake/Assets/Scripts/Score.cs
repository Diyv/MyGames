using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    int score = 0;
    static private string highScoreString = "highscore";
    [SerializeField] TextMeshProUGUI textMeshProScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    private void Start()
    {
        UpdateHighScore();
    }
    
    public void ResetScore()
    {
        SetHighScore(score);
        UpdateHighScore();
        score = 0;
        textMeshProScoreText.text = score.ToString();
    }

    private void SetHighScore(int highScore)
    {
        int recordedScore = PlayerPrefs.GetInt(highScoreString,0);

        if(highScore > recordedScore ){
            recordedScore = highScore;
            PlayerPrefs.SetInt(highScoreString,recordedScore);
        }
    }

    public int GetScore(){
        return score;
    }

    public void UpdateScore(){               
        score = score + 10;
        textMeshProScoreText.text = score.ToString();
    }

    public int GetHighScore(){
        int highScore = PlayerPrefs.GetInt(highScoreString);   
        return highScore;
    }

    public void UpdateHighScore(){
        highScoreText.text = "High Score: " + GetHighScore().ToString();
    }

    public void ResetHighScore(){
        PlayerPrefs.DeleteKey(highScoreString);
        highScoreText.text = "High Score: 0";
    }
}
