﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> prefabs;
    private const float spawnRate = 2.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;


    private int score = 0;
    public bool gameActive = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        
    }

    public void GameOver()
    {
        gameActive = false;
        gameOverText.gameObject.SetActive(true);
       
    }

    IEnumerator SpawnTarget()
    {
        while(gameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
        }

    }

    public void UpdateScore(int scoreDelta)
    {
        score += scoreDelta;
        if(score<0)
        {
            score = 0;
        }
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
