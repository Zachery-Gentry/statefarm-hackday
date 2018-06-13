using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnter : MonoBehaviour {
	//must have 2 entered to move on
	int playersEntered = 0;
	AreaManager areaManager;

	private void Start() {
		areaManager = transform.parent.gameObject.GetComponent<AreaManager>();
	}

	private void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")){
			playersEntered++;
		}
		if(playersEntered==2){
			areaManager.nextTarget();
		}
	}
	private void OnTriggerExit(Collider other) {
		if(other.CompareTag("Player")){
			playersEntered--;
		}
	}
}
