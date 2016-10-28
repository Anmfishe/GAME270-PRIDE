using UnityEngine;
using System.Collections;

public class SkyScript : MonoBehaviour {
    private int numClouds;
    private Color skyColor;
	// Use this for initialization
	void Start () {
        skyColor = GetComponent<Renderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
        Color temp = skyColor;
        numClouds = GameObject.FindGameObjectsWithTag("Cloud").Length;
        for(int i =0; i < numClouds; i++)
        {
            temp.r -= 0.3f;
            temp.g -= 0.3f;
            temp.b -= 0.3f;

        }
        GetComponent<Renderer>().material.color = temp;

	}
}
