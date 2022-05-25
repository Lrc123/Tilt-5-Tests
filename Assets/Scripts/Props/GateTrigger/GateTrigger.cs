using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{

    [SerializeField]
    List<Transform> itemList;

    public GameObject target;

    public float openRotation;

    public float closeRotation;

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
            Debug.Log("Open The Door!");
            float deltaAngle = (target.transform.eulerAngles - new Vector3(0, openRotation, 0)).magnitude;
            if (deltaAngle > 10f && deltaAngle < 350f)
            {
                target.transform.eulerAngles = Vector3.Lerp(target.transform.eulerAngles, new Vector3(0, openRotation, 0), 0.01f);
            }
            if (!reapeared)
            {
                StartCoroutine(ReapperAll());
            }
        }
        else
        {
            float deltaAngle = (target.transform.eulerAngles - new Vector3(0, closeRotation, 0)).magnitude;
            if (deltaAngle > 10f && deltaAngle < 350f)
            {
                target.transform.eulerAngles = Vector3.Lerp(target.transform.eulerAngles, new Vector3(0, closeRotation, 0), 0.01f);
            }
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
