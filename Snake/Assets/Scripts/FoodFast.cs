using System;
using System.Collections;
using UnityEngine;

public class FoodFast : MonoBehaviour
{
    [SerializeField] int fastTime = 0;
    [SerializeField] int speedup = 3;
    [SerializeField] int countDownFoodFastActive = 5;

    Boolean isCoroutineActive = true;
    void Update()
    {
        
    }

    private void Start()
    {
        
    }

    private IEnumerator CountDownFoodFastActive()
    {
        yield return new WaitForSeconds(countDownFoodFastActive);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            fastTime = fastTime + speedup;

            if(isCoroutineActive)
            {
                StartCoroutine(FastTime()); 
            }
            
        }   
    }

    private IEnumerator FastTime()
    {
        while(fastTime > 0)
        {
            isCoroutineActive = false;
            Time.timeScale = 2f;
            yield return new WaitForSeconds(1);
            fastTime = fastTime - 1;

            if(fastTime == 0)
            {
                Time.timeScale = 1f;
                isCoroutineActive = true;
                gameObject.SetActive(false);
            }
        }
       
    }

    public Boolean GetIsRoutineActive(){
        return isCoroutineActive;
    }
}
