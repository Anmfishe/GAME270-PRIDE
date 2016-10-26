using UnityEngine;
using System.Collections;

public class LevelupAudio : MonoBehaviour {
    bool first = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Renderer r;
        r = GetComponent<Renderer>();
        Color c;
        c = r.material.color;
	if(!first&&c.a==255)
        {
            first = true;
            AudioSource a = GetComponent<AudioSource>();
            a.Play();
        }
	}
}
