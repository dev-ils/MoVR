package dev_ils.sensordata;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.TextView;
import com.estimote.examples.demos.R;
import com.estimote.sdk.BeaconManager;
import com.estimote.sdk.Nearable;
import java.util.List;

public class EstimoteData {

    private Nearable currentNearable;
    private BeaconManager beaconManager;

    public double[] getAccValue(){

        int counter;
        // 0 = x, 1 = z
        double[] acc = new double[2];
        for (Nearable nearable : nearables) {

            //xMean
            acc[0] += nearable.xAcceleration;
            //zMean
            acc[1] += nearable.zAcceleration;
            counter++;

            StringBuilder builder = new StringBuilder()
                    .append("Identifier: ").append(nearable.identifier).append("\n")
                    .append(String.format("Motion Data: x: %.0f   y: %.0f   z: %.0f", nearable.xAcceleration, nearable.yAcceleration, nearable.zAcceleration)).append("\n")
                    .append("Orientation: ").appendnearable.orientation.toString());
            Log.d(builder);

        }

        acc[0] = acc[0]/counter;
        acc[1] = acc[1]/counter;

        StringBuilder builder = new StringBuilder()
                .append("Identifier: ").append(currentNearable.identifier).append("\n")
                .append(String.format("Motion Data: x: %.0f   y: %.0f   z: %.0f", currentNearable.xAcceleration, currentNearable.yAcceleration, currentNearable.zAcceleration)).append("\n")
                .append("Orientation: ").append(currentNearable.orientation.toString());

        return acc;
    }


    /*
    * TODO On resume, not sure wich activity?
    *
    *
    *
      beaconManager.connect(new BeaconManager.ServiceReadyCallback() {
        @Override public void onServiceReady() {
            beaconManager.startNearableDiscovery();
        }
      });

    */



}
