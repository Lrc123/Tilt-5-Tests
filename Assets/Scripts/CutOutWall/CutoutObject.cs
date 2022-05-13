using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutoutObject : MonoBehaviour
{
    [SerializeField]
    private Transform targetObject;

    public LayerMask wallMask;

    [SerializeField]
    private Camera mainCamera;

    private void Awake()
    {
    }
    private void Start()
    {
        targetObject = transform;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        Vector2 cutoutPos = mainCamera.WorldToViewportPoint(targetObject.position);
        cutoutPos.y /= (Screen.width / Screen.height);

        Vector3 offset = targetObject.position - mainCamera.transform.position;
        RaycastHit[] hitObjects = Physics.RaycastAll(mainCamera.transform.position, offset, offset.magnitude, wallMask);

        for (int i = 0; i < hitObjects.Length; ++i)
        {
            Debug.Log(hitObjects[i].transform.name);
            Material[] materials = hitObjects[i].transform.GetComponent<Renderer>().materials;

            for(int m = 0; m < materials.Length; ++m)
            {
                materials[m].SetVector("_CutoutPos", cutoutPos);
                materials[m].SetFloat("_CutoutSize", 0.1f);
                materials[m].SetFloat("_FalloffSize", 0.05f);
            }
        }
    }
}
