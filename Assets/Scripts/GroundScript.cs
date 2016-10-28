using UnityEngine;
using System.Collections;

public class GroundScript : MonoBehaviour {
    private int numWeeds;
    private Renderer rend;
    private Color origColor;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        origColor = rend.material.color;
	}
	
	// Update is called once per frame
	void Update () {
        numWeeds = GameObject.FindGameObjectsWithTag("Weed").Length;
        Color tempColor = origColor;
        for(int i = 0; i < numWeeds; i++)
        {
            tempColor.r += 0.3f;
        }
        GetComponent<Renderer>().material.color = tempColor;
	
	}
}
