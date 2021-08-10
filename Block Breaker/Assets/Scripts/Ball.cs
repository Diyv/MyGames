using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    //Config Paramethers
    [SerializeField] Paddle paddle_1;
    [SerializeField] float x_velocity = 1f;
    [SerializeField] float y_velocity = 15f;
    [SerializeField] AudioClip[] audio_clips_ball;
    [SerializeField] float ball_random_velocity = 0.2f;
    [SerializeField] float ball_position = 0.60f;

    //State Variables
    Vector2 paddle_to_ball_vector;
    Boolean ball_lunch = false;

    //Component
    Rigidbody2D ball_rigidbody2D;


    // Start is called before the first frame update
    void Start()
    {
        //Using for BallPosition2
        ball_rigidbody2D = GetComponent<Rigidbody2D>();

        paddle_to_ball_vector = transform.position - paddle_1.transform.position;

        paddle_1 = FindObjectOfType<Paddle>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ball_lunch == false) 
        { 
            PositionBall();
            LunchToBallOnClick();
        }
    }

    private void LunchToBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ball_rigidbody2D.velocity = new Vector2(x_velocity, y_velocity);
            ball_lunch = true;
        }
    }

    public void PositionBall()
    {
        
        
        Vector2 ball_vector = new Vector2(paddle_1.transform.position.x, paddle_1.transform.position.y);

        ball_vector.x = paddle_1.transform.position.x;
        ball_vector.y = paddle_1.transform.position.y + ball_position;

        transform.position = ball_vector;

    }

    private void PositionBall2()
    {
        Vector2 paddle_vector = new Vector2(paddle_1.transform.position.x, paddle_1.transform.position.y);

        Vector2 ball_vector = paddle_vector + paddle_to_ball_vector;

        transform.position = ball_vector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ball_lunch)
        {
            //Get the clip from an array which contains clips
            AudioClip clip = audio_clips_ball[Random.Range(0, audio_clips_ball.Length)];

            //play clip it
            GetComponent<AudioSource>().PlayOneShot(clip);

            AddRandomVelocity();
        }
    }

    private void AddRandomVelocity()
    {
        float random_velocity = Random.Range(-1*ball_random_velocity, ball_random_velocity);

        Debug.Log(random_velocity);

        Vector2 random_velocity_vector2 = new Vector2(random_velocity, random_velocity);

        GetComponent<Rigidbody2D>().velocity += random_velocity_vector2; 
    }

}
