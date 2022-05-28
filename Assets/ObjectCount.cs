using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectCount : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int count = 0;
    private int totalCount;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void SetTotalCount(int num)
    {
        totalCount = num;
        GetComponent<TextMeshProUGUI>().text = count.ToString() + " / " + totalCount.ToString();
        print("set total count to " + totalCount);
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
