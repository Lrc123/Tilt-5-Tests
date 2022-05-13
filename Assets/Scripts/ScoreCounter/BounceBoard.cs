using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBoard : MonoBehaviour
{
    private ScoreManager scoreManager;
    private SfxManager sfxManager;
    public Renderer glowRenderer;
    public Material emissiveMaterial;
    private Color originalColor;
    private Color curColor;

    public float timeCounting = 0;
    public float scoreType = 5;
    public GameObject scorePop;
    public GameObject popEffect;
    [SerializeField]
    private float duration = 1;
    private float intensity = 5f;
    private GameObject tmpScorePop;

    // Start is called before the first frame update
    void Start()
    {
        sfxManager = FindObjectOfType<SfxManager>();
        glowRenderer = GetComponent<Renderer>();
        emissiveMaterial = glowRenderer.GetComponent<Renderer>().material;
        emissiveMaterial.EnableKeyword("_EMISSION");
        curColor = originalColor = emissiveMaterial.color;
        //scorePop = GameObject.FindGameObjectWithTag("Score Pop");
        tmpScorePop = Instantiate(scorePop, transform.position + new Vector3(0, 3, 0), Quaternion.identity);
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if((Time.time - timeCounting) >= duration)
        {
            Debug.Log(Time.time - timeCounting);
            if (emissiveMaterial.GetColor("_EmissionColor") != originalColor)
            {
                emissiveMaterial.SetColor("_EmissionColor", originalColor);
            }
        }


    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        scoreManager.score += scoreType;
        sfxManager.PlayBumperSound();
        timeCounting = Time.time;
        curColor = originalColor * intensity;
        emissiveMaterial.SetColor("_EmissionColor", curColor);
        tmpScorePop.transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetTrigger("Pop");
        //scorePop.GetComponent<Animator>().SetTrigger("Pop");
        GameObject bumperEffect = GameObject.Instantiate(popEffect, transform.position + new Vector3(0, 3, 0), Quaternion.identity);

        Destroy(bumperEffect, 1);
    }
}
