using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private ProjectileGroupController groupControllerScript;
    

    // Start is called before the first frame update
    void Start()
    {
        groupControllerScript = GameObject.Find("ProjectileGroup").GetComponent<ProjectileGroupController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane"){
            // Collided with plane, regenerate and destroy
            groupControllerScript.CreateNewProjectile();
            Destroy(this.gameObject);
        } else {
            if (collision.gameObject.name == "Player"){
                // Collided with Player, make player smaller
                GameObject.FindGameObjectWithTag("Player").transform.localScale *= 0.8f; 
            }
        }
     }

     void OnCollisionEnd(Collision collision)
     {

     }
}
