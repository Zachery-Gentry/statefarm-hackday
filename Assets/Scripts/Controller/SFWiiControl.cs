using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WiimoteApi;

public class SFWiiControl : MonoBehaviour
{

    private Wiimote wiimote;

    // Use this for initialization
    void Start()
    {
        WiimoteManager.FindWiimotes();

        if (!WiimoteManager.HasWiimote())
        {
            Debug.Log("Yo no wiimote");
        }
        else
        {
			wiimote = WiimoteManager.Wiimotes[0];
            Debug.Log("I found a wiimote");
        }

        wiimote.SendDataReportMode(InputDataType.REPORT_BUTTONS_ACCEL);

    }

	private void Update() {
		wiimote.ReadWiimoteData();
		GetAccelVector();
	}

	 private Vector3 GetAccelVector()
    {
        float accel_x;
        float accel_y;
        float accel_z;

        float[] accel = wiimote.Accel.GetCalibratedAccelData();
        accel_x = accel[0];
        accel_y = -accel[2];
        accel_z = -accel[1];
        Debug.Log(accel_x + " " + accel_y + " " + accel_z);
        return new Vector3(accel_x, accel_y, accel_z).normalized;
    }

}
