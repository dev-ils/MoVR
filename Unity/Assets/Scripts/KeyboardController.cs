using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour {

	public float speed = 300F;
	
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

		// Makes the camera follow the height of the terrain
		float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);
		transform.position = new Vector3(transform.position.x, terrainHeight + 5, transform.position.z);
	}
}
