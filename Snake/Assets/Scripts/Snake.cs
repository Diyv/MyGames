using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using UnityEngine;


public class Snake : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float movementGap = 1f;
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    
    public int startingSize = 4;
    String controlLastKey = "right";
    Score score;
    FoodFast fastfood;

    private void Start()
    {
        score = FindObjectOfType<Score>();
        ResetGame();
    }

    private void Update()
    {
        GetKeyDownValue();
    }

    private void FixedUpdate()
    {
        MoveSnake();
    }

    private void GetKeyDownValue()
    {
        if (Input.GetKeyDown(KeyCode.W) && controlLastKey != "down")
        {
            _direction = new Vector2(0,1 * movementGap);
            controlLastKey = "up";
        }
        else if (Input.GetKeyDown(KeyCode.A) && controlLastKey != "right")
        {
            _direction = new Vector2(movementGap * -1, 0);
            controlLastKey = "left";
        }
        else if (Input.GetKeyDown(KeyCode.S) && controlLastKey != "up")
        {
            _direction = new Vector2(0,-1 * movementGap);
            controlLastKey = "down";
        }
        else if (Input.GetKeyDown(KeyCode.D) && controlLastKey != "left")
        {
            _direction = new Vector2(movementGap * 1, 0);
            controlLastKey = "right";
        }
    }

/*
    private void MoveSnake2(){

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == movementGap)
            {
                movePoint.position += new Vector3(Input.GetAxis("Horizontal"),0.0f,0.0f);
            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == movementGap)
            {
                movePoint.position += new Vector3(0.0f ,Input.GetAxis("Vertical"),0.0f);
            }
        }
      
    }
    */

    private void MoveSnake()
    {

        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + _direction.x,
        Mathf.Round(this.transform.position.y) + _direction.y, 0.0f);
    }

    private void Grow(){

        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);  

        /*
        if(fastfood.GetIsRoutineActive()){
            for (int i = 0; i < 5; i++)
            {
                segment = Instantiate(this.segmentPrefab);
                segment.position = _segments[_segments.Count - 1].position;

                _segments.Add(segment);  
            }
        }     
        */ 
    }


    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.tag == "Food"  || other.tag == "FoodFast"){
            Grow();
            score.UpdateScore();
        }

        if (other.tag == "Obstacle"){
            ResetGame();
        }
    }

    private void ResetGame()
    {
        for (int i = 1; _segments.Count > i; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < this.startingSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero;
        score.ResetScore();

    }

   

}
