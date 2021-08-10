using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    GameStatus gameStatus;
    [SerializeField] float screen_with_in_unuts = 16f;
    [SerializeField] float x_min = 1f;
    [SerializeField] float x_max = 15f;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        float paddle_coordinate;

       Vector2 paddle_position_vector2 = new Vector2(transform.position.x, transform.position.y);

       paddle_position_vector2.x = Mathf.Clamp(GetXPos(), x_min, x_max);
       paddle_position_vector2.y = 0.34f;

       transform.position = paddle_position_vector2;

    }

    private float GetXPos()
    {
        if (gameStatus.IsAutoPilotOn())
        {
            return FindObjectOfType<Ball>().transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screen_with_in_unuts;
        }
    }



}
