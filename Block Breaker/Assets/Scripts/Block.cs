using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Config Parameters
    [SerializeField] int block_score;
    [SerializeField] AudioClip break_sound;
    [SerializeField] GameObject block_sparkles_VFX;
    [SerializeField] Sprite[] block_sprites_states;
    [SerializeField] GameObject buff;

    //Cached Reference
    Level level;

    //State Variables
    [SerializeField] int times_hit_to_block = 0; //Serialized for debug purpose

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {      

        if (tag == "Breakable")
        {
            HandleHit();
            DublicateBall();
        }

    }

    private void HandleHit()
    {
        int block_hit_point = block_sprites_states.Length + 1;
        times_hit_to_block++;

        if (times_hit_to_block >= block_hit_point)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextSprite();
        }
    }

    private void ShowNextSprite()
    {
        int sprite_index = times_hit_to_block - 1;
        int last_index = block_sprites_states.Length - 1;

        if (block_sprites_states[sprite_index] != null)
        {
            if (times_hit_to_block >= block_sprites_states.Length + 1)
            {
                GetComponent<SpriteRenderer>().sprite = block_sprites_states[last_index];
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = block_sprites_states[sprite_index];
            }
        }
        else
        {
            Debug.Log("Block Sprite Missing in Array: " + gameObject.name); 
        }
        
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameStatus>().AddScoreToPlayer();
        level.DestroyedBlocks();
        PlaySoundEffectSFX();
        TriggerParticalEffect();

        Destroy(gameObject);
    }

    private void PlaySoundEffectSFX()
    {
        AudioSource.PlayClipAtPoint(break_sound, Camera.main.transform.position);
    }

    public int GetBlockScore()
    {
        return block_score;
    }

    private void TriggerParticalEffect()
    {
        GameObject sparkles = Instantiate(block_sparkles_VFX, transform.position, transform.rotation);
        sparkles.GetComponent<ParticleSystem>().startColor = GetColor();
        Destroy(sparkles, 1f);
    }

    public void DublicateBall()
    {
        GameObject dublicate_ball = Instantiate(buff, transform.position, transform.rotation);
    }

    public Color GetColor()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        Color color = sprite.color; 
        return color;
    }

    private void ChanceParticalEffectColor()
    {
        block_sparkles_VFX.GetComponent<ParticleSystem>().startColor = GetColor();
    }


}
