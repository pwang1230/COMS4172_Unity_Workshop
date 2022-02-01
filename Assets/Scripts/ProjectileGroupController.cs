using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGroupController : MonoBehaviour
{
    public int numberOfProjectiles;
    public GameObject projectilePrefab;
    public float height_min;
    public float height_max;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfProjectiles; i++){
            CreateNewProjectile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateNewProjectile()
    {
        GameObject new_obj = GameObject.Instantiate(projectilePrefab);
        new_obj.transform.SetParent(GameObject.Find("ProjectileGroup").transform);
        Vector3 location = new Vector3(Random.Range(-0.9f,0.9f),Random.Range(height_min,height_max),Random.Range(1.2f,-2.2f));
        new_obj.transform.position = location;
        new_obj.transform.eulerAngles = new Vector3(Random.Range(0,360),Random.Range(0,360),Random.Range(0,360));
    }
}
