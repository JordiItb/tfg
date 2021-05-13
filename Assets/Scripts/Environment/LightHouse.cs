using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHouse : MonoBehaviour
{
    Vector3 pos;
    public float rotation;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotation * Time.deltaTime, 0f, Space.World);
    }
}
