using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnter : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		Debug.Log("This is what entered" + other.tag);
	}
}
