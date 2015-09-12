using UnityEngine;
using System.Collections;

public class EstimoteListener : MonoBehaviour {

	private AndroidJavaObject estimoteData = null;
	bool hasClicked = false;
	
	void Start() {
		if(estimoteData == null) {
			
			using(AndroidJavaClass pluginClass = new AndroidJavaClass("dev_ils.sensordata.FlicData")) {
				if(pluginClass != null) {
					estimoteData = pluginClass.CallStatic<AndroidJavaObject>("instance");
					estimoteData.Call<bool>("hasClicked");
				}
			}
		}
	}
}
