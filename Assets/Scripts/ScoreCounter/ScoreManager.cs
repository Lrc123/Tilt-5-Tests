using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float score = 0;
    public GameObject oneCard;
    public GameObject tenCard;
    public GameObject hundredCard;
    public float[] scoreCard;
    // Start is called before the first frame update
    void Start()
    {
        scoreCard = new float[3];
        scoreCard[0] = 0;
        scoreCard[1] = 0;
        scoreCard[2] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreCheck();
    }

    void CardFlip(int i)
    {
        if (i == 0)
        {
            oneCard.GetComponent<Animator>().SetTrigger("Flip");
            scoreCard[0] = score % 10;
            oneCard.transform.GetChild(0).GetComponent<Text>().text = scoreCard[0].ToString();
        }
        if (i == 1)
        {
            tenCard.GetComponent<Animator>().SetTrigger("Flip");
            scoreCard[1] = Mathf.Floor((score % 100) / 10);
            tenCard.transform.GetChild(0).GetComponent<Text>().text = scoreCard[1].ToString();
        }
        if (i == 2)
        {
            hundredCard.GetComponent<Animator>().SetTrigger("Flip");
            scoreCard[2] = Mathf.Floor((score / 100) % 10);
            hundredCard.transform.GetChild(0).GetComponent<Text>().text = scoreCard[2].ToString();
        }
    }

    void ScoreCheck()
    {
        if (score % 10 != scoreCard[0])
        {
            //scoreCard[0] = score % 10f;
            CardFlip(0);
            return;
        }
        if (Mathf.Floor((score % 100)/10) != scoreCard[1])
        {
            //scoreCard[1] = score / 100;
            CardFlip(1);
            return;
        }
        if (Mathf.Floor((score / 100)%10) != scoreCard[2])
        {
            //scoreCard[2] = score / 100;
            CardFlip(2);
            return;
        }
    }
}
