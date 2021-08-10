using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    NextScenes next_scene;
    [SerializeField] int breakable_objects;

    public void CountBlocks()
    {
        breakable_objects++;
    }

    public void DestroyedBlocks() 
    {
        breakable_objects--;

        if (breakable_objects <= 0)
        {
            next_scene.NextScene();
        }
    }

    private void Start()
    {
        next_scene = FindObjectOfType<NextScenes>();
    }

}
