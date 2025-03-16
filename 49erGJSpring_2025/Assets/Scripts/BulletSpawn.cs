using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    float spawnSpeed = 2;
    private Random random = new Random();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ContinuousSpawnBullet());
    }

    IEnumerator ContinuousSpawnBullet()
    {
        while (true)
        {
            if (ScoreHandler.instance.runTimer)
            {
                
                //select edge
                //place on random point on edge
                GameObject proj = Instantiate(bullet);
                proj.transform.position = this.transform.position;
            }
            yield return new WaitForSeconds(spawnSpeed);
        }
    }
}
