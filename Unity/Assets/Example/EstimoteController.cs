using UnityEngine;
using System.Collections;
using System;

public class EstimoteController : MonoBehaviour {

	public Camera cam;
	private float characterHeight = 2F;
	private float acceleration = 0.0F;
	private float accelerationTarget = 0.0F;
	private bool accelerationTargetReached = true;

	private ArrayList values = new ArrayList();

	// Use this for initialization
	IEnumerator Start () {
		WebSocket w = new WebSocket(new Uri("ws://178.62.242.126:8000/"));
		yield return StartCoroutine(w.Connect());
		int i=0;
		while (true)
		{
			string reply = w.RecvString();
			if (reply != null)
			{
				float newAccelerationTarget = parseAcceleration(reply);
				if(newAccelerationTarget > 0.1f){

					accelerationTargetReached = false;
					accelerationTarget = 1.0f;
				}

				moveCharacter();
				Debug.Log ("Received: "+reply);
			}
			if (w.Error != null)
			{
				Debug.LogError ("Error: "+w.Error);
				break;
			}
			yield return 0;
		}
		w.Close();
	}

	public void FixedUpdate() {

		bool sav = accelerationTargetReached;

		if (!accelerationTargetReached) {
			acceleration = acceleration + 0.001f;

			if(acceleration > 0.15f){
				acceleration = 0.15f;
				accelerationTargetReached = true;
			}

		} else {
			acceleration = acceleration - 0.005f;

			if(acceleration < 0f){
				acceleration = 0f;
			}
		}

		if (accelerationTargetReached == false && acceleration >= accelerationTarget) {
			accelerationTargetReached = true;
		}

		moveCharacter ();
	}

	public void moveCharacter(){
		//Vector3 target = new Vector3 (transform.position.x, transform.position.y, transform.position.z + acceleration);
		//transform.position = Vector3.MoveTowards(transform.position, target, acceleration);
	
		transform.Translate(new Vector3(0f, 0f, acceleration * 0.1f));

		// Makes the camera follow the height of the terrain
		float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);
		transform.position = new Vector3(transform.position.x, terrainHeight + characterHeight, transform.position.z);
	}

	public float parseAcceleration(string json){

		if (json.Contains ("connected") || json.Contains ("Hello") || json.Contains ("Error")) {
			return 0.0f;
		}

		string res = json.Replace (" ", "");
		res = res.Substring (res.IndexOf ("-") + 1);

		float resVal = float.Parse(res);

		resVal = resVal - 400f;
		if (resVal < 0f) {
			resVal = 0f;
		}

		if(resVal > 500f){
			resVal = 500f;
		}

		resVal = resVal * 0.01f;

		return resVal;
	}
}
