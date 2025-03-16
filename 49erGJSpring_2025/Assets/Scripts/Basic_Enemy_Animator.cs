using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Basic_Enemy_Animator : MonoBehaviour
{
    [SerializeField]
    List<Sprite> sprites;
    [SerializeField]
    float animationSpeed = 2;
    [SerializeField]
    SpriteRenderer renderer;
    [SerializeField]
    Sprite prev;
    private Random random = new Random();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ContinuousChangeSprite());
    }

    IEnumerator ContinuousChangeSprite()
    {
        while (true)
        {
            int rand = random.Next(sprites.Count - 1);
            renderer.sprite = sprites[rand];
            sprites.Add(prev);
            prev = sprites[rand];
            sprites.RemoveAt(rand);
            yield return new WaitForSeconds(animationSpeed);
        }
    }
}
