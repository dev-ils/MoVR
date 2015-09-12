using UnityEngine;
using System.Collections;

public class FlicListener : MonoBehaviour {
	
	private AndroidJavaObject flicData = null;
	bool hasClicked = false;
	
	void Start() {
		if(flicData == null) {

			using(AndroidJavaClass pluginClass = new AndroidJavaClass("dev_ils.sensordata.FlicData")) {
				if(pluginClass != null) {
					flicData = pluginClass.CallStatic<AndroidJavaObject>("instance");
					flicData.Call<bool>("hasClicked");
				}
			}
		}
	}
}