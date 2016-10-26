using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour {
    private float speed;
	// Use this for initialization
	void Start () {
        speed = Random.Range(0.001f, 0.04f);
	}
	
	// Update is called once per frame
	void Update () {

	
	}
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        if(transform.position.x > 10f)
        {
            Destroy(this.gameObject);
        }
    }
    void OnMouseDown()
    {
        Destroy(this.gameObject);
    }
}
