using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class player : MonoBehaviour {

	private Rigidbody body;
	//the above command make possible sett the speed value via menu
	[SerializeField]
	private float speed; 

	//Length in Z of an object that we wanna build
	private float lengthZ = 7.6f;

	//Which platform and fence I wanna build
	[SerializeField]
	private GameObject platform;
	[SerializeField]
	private GameObject fence;

	//Whats the first object is?
	[SerializeField]
	Transform firstObject;

	//This holds the last position in each loop
	Vector3 lastPosition;

	//This function, spawn X objects in front of him
	private void spawning(){
		
		//Create one object called OBJ that is the same as an platform
		GameObject plt = Instantiate (platform) as GameObject;
		GameObject fnc = Instantiate (fence)    as GameObject;

		//Here, is setted the perfect position of the next object
		plt.transform.position = lastPosition + new Vector3 (0f, 0f, lengthZ);
		fnc.transform.position = lastPosition + new Vector3 (0f, 0f, lengthZ);
		//next "last" position
		lastPosition = plt.transform.position;
	}

	// Use this for initialization
	void Start () {

		lastPosition = firstObject.transform.position;

		//get the actuall rigidbody
		body = this.GetComponent<Rigidbody>();
		//Setting the velocity
		body.velocity = new Vector3(0f, 0f, speed);

		InvokeRepeating ("spawning",0f,  0.3f);

	}
	
	// Update is called once per frame
	void Update () {
		//check if some key was pressed
		float amToMove = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;

		// A partir do valor gerado acima, ele se move, para direita e para esquerda
		//Only move if is on limit in x.
		transform.Translate (Vector3.right * amToMove);

		if (transform.position.x <= -1.62)
			transform.position = new Vector3 (-1.61f, transform.position.y, transform.position.z);
		else if (transform.position.x >= 1.61)
			transform.position = new Vector3 (1.60f, transform.position.y, transform.position.z);	
		
		Debug.Log (transform.position.x);

	}
}
