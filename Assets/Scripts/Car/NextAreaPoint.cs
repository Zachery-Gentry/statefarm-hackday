using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextAreaPoint : MonoBehaviour
{
    AreaManager areaManager;
    // Use this for initialization
    void Start()
    {
        areaManager = GameObject.FindWithTag("AreaManager").GetComponent<AreaManager>();
    }

    private void Update()
    {
		transform.LookAt(areaManager.getCurrentTargetArea().transform);
		Vector3 lookatRotaiton = transform.localEulerAngles;
		// lookatRotaiton.x += 90;
		lookatRotaiton.y += 90;
		transform.Rotate(lookatRotaiton);
    }
}