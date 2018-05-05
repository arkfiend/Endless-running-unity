using UnityEngine;
using System.Collections;

public class followingCamera : MonoBehaviour {

	[SerializeField]
	Transform target; //Target followed

	//Vector3 offset;




	// Use this for initialization
	void Start () {
		//-aula 3 - Vector3 offset = target.transform.position - this.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		//aula 3 - Following and jumping
		//Vector3 pos = target.transform.position - offset;
		//this.transform.position = Vector3.Lerp (this.transform.position, pos, 1.5f);

		this.transform.position = new Vector3 (target.transform.position.x, target.transform.position.y+3f, target.transform.position.z-5.8f);
	}



}
