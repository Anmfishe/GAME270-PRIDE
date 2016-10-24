using UnityEngine;
using System.Collections;

public class TreeScript : MonoBehaviour {
    public GameObject rbranch;
    public GameObject lbranch;
    private HingeJoint2D hj2d;
    private AudioSource a;
	// Use this for initialization
	void Start () {
        a = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void reload()
    {
        Application.LoadLevel("Level1");
    }
    void FixedUpdate()
    {
        float rnum = 0;
        float lnum = 0;
        foreach(Transform child in transform)
        {
            if(child.tag == "RightBranch")
            {
                rnum += child.transform.lossyScale.x + child.transform.lossyScale.y;
            }
            if (child.tag == "LeftBranch")
            {
                lnum += child.transform.lossyScale.x + child.transform.lossyScale.y;
            }
        }
        if(rnum > lnum * 2.5)
        {
            hj2d = rbranch.GetComponent<HingeJoint2D>();
            hj2d.breakForce = 0f;
            a.Play();
            Invoke("reload", 2.5f);
        }
        if (lnum > rnum * 2.5)
        {
            hj2d = lbranch.GetComponent<HingeJoint2D>();
            hj2d.breakForce = 0f;
            a.Play();
            Invoke("reload", 2.5f);
        }
    }
    
}
