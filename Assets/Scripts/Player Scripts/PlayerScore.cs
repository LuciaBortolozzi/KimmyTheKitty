﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    [SerializeField]
    private AudioClip birdClip, lifeClip;

    private CameraScript cameraScript;

    private Vector3 previousPosition;
    private bool countScore;

    public static int scoreCount;
    public static int lifeCount;
    public static int birdCount;

    private void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }

    private void Start()
    {
        previousPosition = transform.position;
        countScore = true;
    }

    private void Update()
    {
        CountScore();
    }

    void CountScore()
    {
        if (countScore)
        {
            if (transform.position.y < previousPosition.y)
                scoreCount++;
            previousPosition = transform.position;
            GameplayController.instance.SetScore(scoreCount);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bird")
        {
            birdCount++;
            scoreCount += 200;

            GameplayController.instance.SetScore(scoreCount);
            GameplayController.instance.SetBirdScore(birdCount);

            AudioSource.PlayClipAtPoint(birdClip, transform.position);
            target.gameObject.SetActive(false);
        }

        if(target.tag == "Life")
        {
            lifeCount++;
            scoreCount += 300;

            GameplayController.instance.SetScore(scoreCount);
            GameplayController.instance.SetLifeScore(lifeCount);

            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            target.gameObject.SetActive(false);
        }

        if(target.tag == "Bounds" || target.tag == "Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;

            transform.position = new Vector3(500, 500, 0);
            lifeCount--;
            GameManager.instance.CheckGameStatus(scoreCount, birdCount, lifeCount);
        }
    }

}
