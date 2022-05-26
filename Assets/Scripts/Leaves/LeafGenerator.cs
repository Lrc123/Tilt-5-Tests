using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafGenerator : MonoBehaviour
{
    public GameObject leaf;

    public int randAmount;

    public Texture2D texture;

    public Material[] materials;

    void Start()
    {
        //GenerateBaseOnTexture();
        Generate(randAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("Clear!");
            //GenerateBaseOnTexture();
            Generate(randAmount);
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

                    var go = Instantiate(leaf, new Vector3(i * leaf.transform.localScale.x - leaf.transform.localScale.x * texture.width / 2, 5 * leaf.transform.localScale.y , j * leaf.transform.localScale.z - texture.height * leaf.transform.localScale.z / 2) + transform.position, rot, transform);
                    go.GetComponent<Renderer>().material.color = (color);
                    var go1 = Instantiate(leaf, new Vector3(i * leaf.transform.localScale.x - leaf.transform.localScale.x * texture.width / 2, 3 * leaf.transform.localScale.y , j * leaf.transform.localScale.z - texture.height * leaf.transform.localScale.z / 2) + transform.position, rot, transform);
                    go1.GetComponent<Renderer>().material.color = (color);
                    var go2 = Instantiate(leaf, new Vector3(i * leaf.transform.localScale.x - leaf.transform.localScale.x * texture.width / 2, 1 * leaf.transform.localScale.y , j * leaf.transform.localScale.z - texture.height * leaf.transform.localScale.z / 2) + transform.position, rot, transform);
                    go2.GetComponent<Renderer>().material.color = (color);
                }

            }
        }

    }

    void GenerateWithNoise()
    {

    }

    void Generate(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Quaternion rot = new Quaternion(Random.Range(0f, 90f), Random.Range(0f, 90f), Random.Range(0f, 90f), Random.Range(0f, 90f));
            var card = Instantiate(leaf, transform.position + new Vector3(Random.Range(-7.5f, 7.5f), -transform.position.y + 1f, Random.Range(-7.5f, 7.5f)), rot, transform);
            Material newMat = materials[Random.Range(0, materials.Length)];
            card.GetComponent<Renderer>().material = newMat;
            card.transform.GetChild(0).GetComponent<Renderer>().material = newMat;
        }
    }

}
