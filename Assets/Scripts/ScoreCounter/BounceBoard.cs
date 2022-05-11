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
    [SerializeField]
    private float duration = 1;
    private float intensity = 5f;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        sfxManager = FindObjectOfType<SfxManager>();
        glowRenderer = GetComponent<Renderer>();
        emissiveMaterial = glowRenderer.GetComponent<Renderer>().material;
        emissiveMaterial.EnableKeyword("_EMISSION");
        curColor = originalColor = emissiveMaterial.color;
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
        scoreManager.score++;
        sfxManager.PlayBumperSound();
        timeCounting = Time.time;
        curColor = originalColor * intensity;
        emissiveMaterial.SetColor("_EmissionColor", curColor);
    }
}
