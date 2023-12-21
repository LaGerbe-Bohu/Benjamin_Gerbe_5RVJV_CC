using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixcamera : MonoBehaviour
{
    Quaternion dir;
    // Start is called before the first frame update
    void Awake()
    {
        dir = this.transform.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = dir;
    }
}
