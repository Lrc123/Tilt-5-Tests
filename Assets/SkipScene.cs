using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TiltFive;

public class SkipScene : MonoBehaviour
{
    public string nextScene;
    private bool isSkipping = true;
    private int nextSceneIndex = 1;

    private void Start()
    {
        //nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        //isSkipping = false;
        //StopAllCoroutines();
        StartCoroutine(DelayInput());
    }

    // Update is called once per frame
    void Update()
    {
        bool isButtonDown = false;
        TiltFive.Input.TryGetButtonDown(TiltFive.Input.WandButton.B, out isButtonDown);
        if (isButtonDown && !isSkipping)
        {
            SceneManager.LoadScene(nextScene);
            isSkipping = true;
            print("next:" + nextScene);
        }
    }

    IEnumerator DelayInput()
    {
        yield return new WaitForSeconds(1f);
        isSkipping = false;
    }
}
