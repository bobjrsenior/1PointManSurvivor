using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> enemies;
    [SerializeField]
    float spawnSpeed = 2;
    private Random random = new Random();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ContinuousSpawnEnemy());
    }

    IEnumerator ContinuousSpawnEnemy()
    {
        while (true)
        {
            Instantiate(enemies[0]);
            //select edge
            //place on random point on edge
            int side = random.Next(0, 3);
            float point = random.Next(-40, 40);
            float xPos = 0;
            float yPos = 0;
            switch (side)
            {
                case 0:
                    xPos = 40;
                    yPos = point;
                    break;
                case 1:
                    xPos = -40;
                    yPos = point;
                    break;
                case 2:
                    xPos = point;
                    yPos = 40;
                    break;
                default:
                    xPos = point;
                    yPos = -40;
                    break;

            }
            GameObject enemy = Instantiate(enemies[0]);
            enemy.transform.position = new Vector3(xPos, yPos, 0);
            yield return new WaitForSeconds(spawnSpeed);
        }
    }
}
