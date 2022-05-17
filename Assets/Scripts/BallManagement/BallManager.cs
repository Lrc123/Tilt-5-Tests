using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public int maxBalls = 10;
    public float spawnRate = 2f;

    private int ballCount = 0;

    private BallSpawner ballSpawner;
    private BallExit ballExit;

    private void Start()
    {
        ballSpawner = GetComponentInChildren<BallSpawner>();
        ballExit = GetComponentInChildren<BallExit>();
        StartCoroutine(SpawnBalls());
    }

    private IEnumerator SpawnBalls()
    {
        while (true)
        {
            if (ballCount < maxBalls)
            {
                ballSpawner.SpawnBall();
                ++ballCount;
            }

            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void DecrementBallCount()
    {
        ballCount = Mathf.Max(ballCount - 1, 0);
    }
}
