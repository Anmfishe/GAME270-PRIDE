using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public GameObject sky;
    private int numClouds;
    private Camera cam;
    private Color camColor;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
        camColor = cam.backgroundColor;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        Color temp = camColor;
       ;
        //print(GameObject.FindGameObjectsWithTag("Cloud").Length);
        numClouds = GameObject.FindGameObjectsWithTag("Cloud").Length;
        for(int i = 0; i < numClouds; i++)
        {
            
            temp.r -= 0.05f;
            temp.g -= 0.05f;
            temp.b -= 0.05f;
        }
        cam.backgroundColor = temp;
    
    }
}
