using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private Transform _transform;
    // Start is called before the first frame update
    void Awake()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(_transform.position.y < -3.5f)
        {
            Destroy(gameObject);
        }
    }
}
