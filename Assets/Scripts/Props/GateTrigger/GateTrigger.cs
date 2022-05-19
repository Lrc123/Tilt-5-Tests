using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{

    [SerializeField]
    List<Transform> itemList;


    public GameObject entryObj;

    public GameObject exitObj;

    void Start()
    {
        itemList = new List<Transform>();
        SetupList();
    }

    private void SetupList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            itemList.Add(transform.GetChild(i));
        }
    }

    private bool CheckCompleted()
    {
        for (int i = 0;i < itemList.Count; i++)
        {
            if (!itemList[i].GetComponent<bumperScript>().isDisappered)
            {
                return false;
            }
        }
        return true;
    }

    void Update()
    {
        HandleTrigger();
    }

    bool reapeared = false;

    private void HandleTrigger()
    {
        if (CheckCompleted())
        {
            exitObj.GetComponent<Animator>().SetBool("Open", true);
            Debug.Log("Open The Door!");
            if (!reapeared)
            {
                StartCoroutine(ReapperAll());
            }
        }
        else
        {
            exitObj.GetComponent<Animator>().SetBool("Open", false);
            Debug.Log("Close The Door!");
        }
    }

    private IEnumerator ReapperAll()
    {
        Debug.Log("ReappearedAll" + Time.time);
        reapeared = true;
        yield return new WaitForSeconds(5);
        for (int i = 0; i < itemList.Count; i++)
        {
            itemList[i].GetComponent<bumperScript>().Reappear();
        }
        reapeared = false;
    }
}
