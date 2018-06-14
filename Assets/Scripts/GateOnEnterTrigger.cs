using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOnEnterTrigger : MonoBehaviour {

	private bool isInFrontOfGate;
	public GameObject gateArm;
	private float incrementer = 1.0f;

	public float gateSpeed = 0.5f;
	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player"){
			isInFrontOfGate = true;
			StartCoroutine(openDoor(other));
		}
	}

	private void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Player"){
			isInFrontOfGate = false;
			StartCoroutine(closeDoor());
		}
	}

	private IEnumerator closeDoor(){
		while(incrementer > 0.0f){
			gateArm.transform.rotation = Quaternion.Euler(incrementer, 0.0f, 0.0f);
			incrementer -= gateSpeed;
			if(incrementer < 0.0f){
				incrementer = 0.0f;
			}
			yield return null;
		}
	}

	private IEnumerator openDoor(Collider other){
		while(isInFrontOfGate && incrementer < 30.0f){
			gateArm.transform.rotation = Quaternion.Euler(incrementer, 0.0f, 0.0f);
			incrementer += gateSpeed;
			yield return null;
		}
	}

}
