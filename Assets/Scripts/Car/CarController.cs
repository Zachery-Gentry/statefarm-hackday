using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WiimoteApi;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    
    private Wiimote wiimote;

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

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        // float motor = maxMotorTorque * Input.GetAxis("Vertical");
        // float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        float motor = maxMotorTorque * (wiimote.Button.two ? 1 : 0);
        float wiiAxisNormalized = -wiimote.Accel.GetCalibratedAccelData()[1] + 0.5f;
        float steering = maxSteeringAngle * wiiAxisNormalized;

        Debug.Log("Wii button 2: " + wiimote.Button.two);
        Debug.Log("Wii axis: " + wiiAxisNormalized);

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }
}