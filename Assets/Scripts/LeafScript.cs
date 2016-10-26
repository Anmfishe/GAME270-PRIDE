using UnityEngine;
using System.Collections;

public class LeafScript : MonoBehaviour {
    RaycastHit[] hits;
    // Use this for initialization
    void Start()
    {
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(transform.position, transform.forward, 200f);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];
            if (hit.transform.CompareTag("Sky"))
            {
                break;
            }
            if (hit.transform.CompareTag("Rainbow"))
            {
                Renderer rend = hit.transform.GetComponent<Renderer>();

                if (rend)
                {
                    // Change the material of all hit colliders
                    // to use a transparent shader.
                    Color tempColor = rend.material.color;
                    tempColor.a = 255F;
                    rend.material.color = tempColor;
                }
                break;
            }
        }

    }
    void OnMouseDown()
    {
        
    }
    void FixedUpdate()
    {
        
    
    }
}
