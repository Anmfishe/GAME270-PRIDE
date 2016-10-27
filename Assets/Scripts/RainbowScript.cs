using UnityEngine;
using System.Collections;

public class RainbowScript : MonoBehaviour {
    bool first = false;
	// Use this for initialization
	void Start () {
	
	}
    void loadNextLevel()
    {
        Application.LoadLevel("Level1");
    }
    // Update is called once per frame
    void Update () {
        int count = 0;
	    foreach(Transform child in transform)
        {
            Renderer rend = child.GetComponent<Renderer>();
            Color tempColor = rend.material.color;
            if(tempColor.a == 255)
            {
                count++;

            }
        }
        if(count == 5 &&!first)
        {
            //Invoke("loadNextLevel", 5f);
            AudioSource win = GetComponent<AudioSource>();
            win.Play();
            first = true;
        }
        if (Input.GetKeyDown("r"))
        {
            loadNextLevel();
        }

    }
}
