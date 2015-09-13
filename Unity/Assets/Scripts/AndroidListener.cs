using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AndroidListener : MonoBehaviour {

	public Text textHolder;
	private string statusText = "Failure!";

	// Use this for initialization
	void Start () {
		#if UNITY_ANDROID

		AndroidJavaClass ajc = new AndroidJavaClass("com.lokisystems.oshook.Bridge");
		string ret = ajc.CallStatic<string>("ReturnString");

		Debug.Log("Android: returned " + ret);

		if (ret == null){
			statusText = "Ret null";
		} else if (ajc == null) {
			statusText = "Class null";
		} else {
			statusText = ret;
		}

		#endif
	}
	
	// Update is called once per frame
	void onGui () {
		textHolder.text = statusText;
	}
}
