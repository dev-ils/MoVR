using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour {

	public float speed = 3F;
	private float yPosition = 1F;
	
	// Use this for initialization
	void Start () {
	}
	
	void Update()
	{
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
			transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
			transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
		}
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
			transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
		}

		transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
	}
}
