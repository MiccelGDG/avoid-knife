using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerKnives : MonoBehaviour
{
    public GameObject knifes;

    private float xMin = -2.7f;
    private float xMax = 2.7f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawing());
    }

    IEnumerator StartSpawing()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));
        GameObject k = Instantiate(knifes);
        float x = Random.Range(xMin, xMax);
        k.transform.position = new Vector2(x, transform.position.y);

        StartCoroutine(StartSpawing());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
