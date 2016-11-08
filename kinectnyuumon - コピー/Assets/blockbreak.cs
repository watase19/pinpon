using UnityEngine;
using System.Collections;

public class blockbreak : MonoBehaviour {
	//public GameObject ball;
	Rigidbody rigid;
	Vector3 vec;
	// Use this for initialization
	void Start () {
		rigid = transform.GetComponent<Rigidbody> ();
		rigid.velocity = new Vector3 (0, 10, 0);
		vec = rigid.velocity ;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -10 || transform.position.y > 10) {
			vec.y = -vec.y;
			rigid.velocity = vec;
		}
	}
	void OnCollisionEnter(Collision other) {

		vec.y = -vec.y;
		rigid.velocity = vec;
		Debug.Log (vec);
	}
}
