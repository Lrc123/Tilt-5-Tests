using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TiltFive;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TiltFive.Input.GetTrigger() > 0f)
        {
            SceneManager.LoadScene(1);
        }
    }
}
