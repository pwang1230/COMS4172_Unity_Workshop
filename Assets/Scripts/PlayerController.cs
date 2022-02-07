using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    private Vector3 startPosition;
    public Button restartButton;
    public GameObject canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
        Button buttonComponent = restartButton.GetComponent<Button>();
        buttonComponent.onClick.AddListener(RestartGame);
        originalMat = GetComponent<MeshRenderer>().material;
    }

    void RestartGame()
    {
        this.transform.position = startPosition;
        GameObject projectileGroup = GameObject.Find("ProjectileGroup");
        for (int i = 0; i < projectileGroup.transform.childCount; i++){
            Destroy(projectileGroup.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < projectileGroup.GetComponent<ProjectileGroupController>().numberOfProjectiles; i++){
            projectileGroup.GetComponent<ProjectileGroupController>().CreateNewProjectile();
        }
        canvas.gameObject.SetActive(false);
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Time.timeScale = 1;
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
        
        /*
         * Script for increase the scale of the player sphere
        // The minimum scale of the player is 0.1 and the maximum is 0.3
        Vector3 scale = this.transform.localScale;
        if (scale.x < 0.1f){
            scale = new Vector3(0.1f,0.1f,0.1f);
        } else {
            var scale_val = Mathf.Min(0.3f,scale.x*1.002f);
            scale = new Vector3(scale_val,scale_val,scale_val);
        }
        this.transform.localScale = scale;
        */
    }

    Coroutine coroutine;
    public Material RedMat;
    public Material originalMat;
    public void Hit() {
        if(coroutine!=null)
            StopCoroutine(coroutine);

        StartCoroutine(changeColorForSeconds(0.2f));
    }

    IEnumerator changeColorForSeconds(float seconds)
    {
        GetComponent<MeshRenderer>().material = RedMat;
        yield return new WaitForSeconds(seconds);
        GetComponent<MeshRenderer>().material = originalMat;
    }
}
