using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using WiimoteApi;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        private Wiimote wiimote;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

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

        private void FixedUpdate()
        {
            // pass the input to the car!
            // float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // float v = CrossPlatformInputManager.GetAxis("Vertical");
            wiimote.ReadWiimoteData();
            float v = wiimote.Button.two ? 1 : wiimote.Button.one ? -0.3f : 0;
            float h = -wiimote.Accel.GetCalibratedAccelData()[1] + 0.5f;
            Debug.Log("V: " + v);
            Debug.Log("H: " + h);
#if !MOBILE_INPUT
            // float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, 0f);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
