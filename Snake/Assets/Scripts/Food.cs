using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] float spawnRadiusCheck = 1f;
    GameObject foodFast;
    int count = 0;
    Snake snake;

    [SerializeField] AudioClip audioClip;

    [SerializeField] Collider2D gridArea;

    private void Start()
    {
        foodFast = GameObject.FindGameObjectWithTag("FoodFast");
        RandomizeFootPosition();
    }

    private void RandomizeFootPosition()
    {
        

        Bounds bounds = gridArea.bounds;

        float x = Random.Range(-26, 26);
        float y = Random.Range(-13, 13);


        Debug.Log(x + "  " + y);
        //FindNewFoodLocation(bounds, ref x, ref y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0f);

        ActiveFoodFast(); 
    }

    private void ActiveFoodFast()
    {
        int chanceFastfood = Random.Range(1,5);
        if (chanceFastfood == 1)
        {
            foodFast.SetActive(true);
        }
    }

    private void FindNewFoodLocation(Bounds bounds, ref float x, ref float y)
    {
        count = 0;

        while (Physics2D.OverlapCircleAll(new Vector2(x, y), spawnRadiusCheck).Length > 1 || count > 5)
        {

            Debug.Log(Physics2D.OverlapCircleAll(new Vector2(x, y), spawnRadiusCheck).Length);

            x = Random.Range(bounds.min.x, bounds.max.x);
            y = Random.Range(bounds.min.y, bounds.max.y);

            count++;

            Debug.Log("Times Tried New Location: " + count);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" || other.tag == "Obstacle" || other.tag == "Food"){
            RandomizeFootPosition();
            PlaySound();
        }
        
    }

    private void PlaySound()
    {
        GetComponent<AudioSource>().PlayOneShot(audioClip);
    }

  
}
