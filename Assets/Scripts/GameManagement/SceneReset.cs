using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TiltFive;
using UnityEngine.SceneManagement;

public class SceneReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.B)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
