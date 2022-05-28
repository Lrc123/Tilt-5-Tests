using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCount : MonoBehaviour
{
    private Text text;
    private int count = 0;
    private int totalCount;

    void Start()
    {
        text = GetComponent<Text>();
    }

    public void SetTotalCount(int num)
    {
        totalCount = num;
        UpdateCount(0);
    }

    public void UpdateCount(int add)
    {
        count += add;
        count = Mathf.Clamp(count, 0, totalCount);
        text.text = count.ToString() + " / " + totalCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
