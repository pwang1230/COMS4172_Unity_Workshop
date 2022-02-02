using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private ProjectileGroupController groupControllerScript;
    public int maxCollidedCount;
    private int collidedCount;

    // Start is called before the first frame update
    void Start()
    {
        collidedCount = 0;
        groupControllerScript = GameObject.Find("ProjectileGroup").GetComponent<ProjectileGroupController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" && collidedCount == maxCollidedCount){
            // Collided with plane, regenerate and destroy
            groupControllerScript.CreateNewProjectile();
            Destroy(this.gameObject);
        } else {
            if (collision.gameObject.name == "Player"){
                // Collided with Player, make player smaller
                GameObject.FindGameObjectWithTag("Player").transform.localScale *= 0.8f; 
            }
        }
        collidedCount += 1;
    }
}
