using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 cameraOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = this.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + cameraOffset;
    }
}
