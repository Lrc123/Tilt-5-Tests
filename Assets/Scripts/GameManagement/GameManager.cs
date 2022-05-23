using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject timer;

    public List<GameObject> camPositions;

    public Transform gameBoard;

    public int camIndex = 0;

    private Text timeCount;

    private float timeNum = 60;

    public float startTimeNum = 60;

    private float elapsedTime = 0;

    public GameObject bossShow;

    private bool isPlayed = false;

    void Start()
    {
        timeCount = timer.GetComponent<Text>();
        timeNum = startTimeNum;
    }

    void HandleTimer()
    {
        if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.A))
        {
            timeCount.text = "Timer: " + timeNum.ToString();
            timeNum = startTimeNum;
        }
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 1)
        {
            elapsedTime = 0;
            timeCount.text = "Timer: " + timeNum.ToString();
            if (timeNum > 0)
            {
                timeNum--;
            }
        }
    }


    void Update()
    {
        HandleTimer();
        BossShow();
        SceneReset();
        SwitchLevel();
    }

    void SceneReset()
    {
        if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.A)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void SwitchLevel()
    {
        if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.X))
        {
            camIndex++;
            camIndex %= camPositions.Count;
        }
        else if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.B))
        {
            camIndex--;
            camIndex %= camPositions.Count;
        }
        //gameBoard.position = Vector3.MoveTowards(gameBoard.position, camPositions[camIndex].transform.position, 1.2f);
    }


    void BossShow()
    {
        if (isPlayed)
        {
            return;

        }
        if (timeNum == 0)
        {
            //bossShow.GetComponent<Animator>().SetTrigger("BossShow");
            isPlayed = true;
        }

    }

}
