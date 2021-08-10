using System;
using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField] Boolean auto_pilot = false;
    [SerializeField]TextMeshProUGUI player_score_textmesh;
    [SerializeField]int player_score = 0;
    [Range(0.1f , 10f)][SerializeField] float game_speed = 1f;

    //Cached refrence
    Block block;

    private void Awake()
    {
        int count_game_status = FindObjectsOfType<GameStatus>().Length;
        if (count_game_status > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player_score_textmesh = FindObjectOfType<TextMeshProUGUI>();
        block = FindObjectOfType<Block>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = game_speed;
    }

    private void UpdatePlayerScore()
    {
        player_score_textmesh.text = player_score.ToString();
    }

    public void AddScoreToPlayer()
    {
        player_score = player_score + block.GetBlockScore();
        UpdatePlayerScore();
    }

    public void ResetScoreDestroyItself()
    {
        Destroy(gameObject);
    }

    

    public Boolean IsAutoPilotOn()
    {
        return auto_pilot;
    }



}
