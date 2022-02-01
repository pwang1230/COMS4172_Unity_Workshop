using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            //Debug.Log("w key was pressed");
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-0.5f));
        }
        if (Input.GetKey("s"))
        {
            //Debug.Log("s key was pressed");
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,0.5f));
        }
        if (Input.GetKey("a"))
        {
            //Debug.Log("a key was pressed");
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0.5f,0,0));
        }
        if (Input.GetKey("d"))
        {
            //Debug.Log("d key was pressed");
            this.GetComponent<Rigidbody>().AddForce(new Vector3(-0.5f,0,0));
        }
        
        // The minimum scale of the player is 0.1 and the maximum is 0.3
        Vector3 scale = this.transform.localScale;
        if (scale.x < 0.1f){
            scale = new Vector3(0.1f,0.1f,0.1f);
        } else {
            var scale_val = Mathf.Min(0.3f,scale.x*1.002f);
            scale = new Vector3(scale_val,scale_val,scale_val);
        }
        this.transform.localScale = scale;
    }
}
