using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeafGenerator : MonoBehaviour
{
    public GameObject leaf;
    public GameObject card;

    public GameObject clearShow;

    public int randAmount;

    public Texture2D texture;

    public Material[] cardMaterials;
    public Material[] leafMaterials;

    private ObjectCount objectCount;
    private bool isClear;

    public float multiFactor = 1;
    public bool isTutorial;

    void Start()
    {
        clearShow.SetActive(false);
        objectCount = FindObjectOfType<ObjectCount>();
        //GenerateBaseOnTexture();
        Generate(randAmount);

        //StartCoroutine(AutumnLeaves());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0 && !isClear)
        {
            //Debug.Log("Clear!");
            //GenerateBaseOnTexture();
            //Generate(randAmount);
 
            ClearLevel();
        }
    }

    public void ClearLevel()
    {
        isClear = true;
        // Display clear screen
        if (isTutorial)
        {
            FindObjectOfType<SfxManager>().FadeMusic();
        }
        else
        {
            FindObjectOfType<SfxManager>().PlayClear();
        }
        clearShow.SetActive(true);
        clearShow.GetComponent<Animator>().SetTrigger("Clear");
        StartCoroutine(ToNextLevel());
        
    }

    IEnumerator ToNextLevel()
    {
        yield return new WaitForSeconds(3f);
        // Load next scene
        int nextScene = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextScene);
    }

    void GenerateWithNoise()
    {

    }

    void Generate(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            float randVal = Random.value;
            var objType = randVal < 0.5f ? leaf : card;

            Quaternion rot = new Quaternion(Random.Range(0f, 90f), Random.Range(0f, 90f), Random.Range(0f, 90f), Random.Range(0f, 90f));
            var obj = Instantiate(objType, transform.position + multiFactor * new Vector3(Random.Range(-6f, 6f), Random.Range(-2f, 5f), Random.Range(-6f, 5f)), rot, transform);
            Material newMat = randVal < 0.5f ? leafMaterials[Random.Range(0, leafMaterials.Length)] : cardMaterials[Random.Range(0, cardMaterials.Length)];
            obj.GetComponent<Renderer>().material = newMat;
            obj.GetComponent<LeafBounce>().isTutorial = isTutorial;
        }

        objectCount.SetTotalCount(transform.childCount);
    }

    IEnumerator AutumnLeaves()
    {
        while (Time.timeSinceLevelLoad < 10f)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            Generate(Random.Range(1, 5));
        }
    }

    void GenerateBaseOnTexture()
    {
        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                Color color = texture.GetPixel(i, j);

                if (color.a > 0)
                {
                    Quaternion rot = new Quaternion(Random.Range(0f, 90f), Random.Range(0f, 90f), Random.Range(0f, 90f), Random.Range(0f, 90f));

                    var go = Instantiate(leaf, new Vector3(i * leaf.transform.localScale.x - leaf.transform.localScale.x * texture.width / 2, 5 * leaf.transform.localScale.y, j * leaf.transform.localScale.z - texture.height * leaf.transform.localScale.z / 2) + transform.position, rot, transform);
                    go.GetComponent<Renderer>().material.color = (color);
                    var go1 = Instantiate(leaf, new Vector3(i * leaf.transform.localScale.x - leaf.transform.localScale.x * texture.width / 2, 3 * leaf.transform.localScale.y, j * leaf.transform.localScale.z - texture.height * leaf.transform.localScale.z / 2) + transform.position, rot, transform);
                    go1.GetComponent<Renderer>().material.color = (color);
                    var go2 = Instantiate(leaf, new Vector3(i * leaf.transform.localScale.x - leaf.transform.localScale.x * texture.width / 2, 1 * leaf.transform.localScale.y, j * leaf.transform.localScale.z - texture.height * leaf.transform.localScale.z / 2) + transform.position, rot, transform);
                    go2.GetComponent<Renderer>().material.color = (color);
                }

            }
        }

    }
}
