using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour {

	List<GameObject> targetAreaList = new List<GameObject>();
	int currentActivatedArea = 0;

	private void Start(){
		Transform[] targetAreas = GetComponentsInChildren<Transform>(true);
		foreach(Transform currentArea in targetAreas){
			GameObject nextChild = currentArea.gameObject;
			if(nextChild.CompareTag("TargetArea")){
				targetAreaList.Add(nextChild);
				Debug.Log("added" + nextChild.name);
			}
		}
		Debug.Log("Atempting to activate " + targetAreaList[0].name);
		targetAreaList[0].SetActive(true);
	}

	public void nextTarget(){
		targetAreaList[currentActivatedArea].SetActive(false);
		currentActivatedArea++;
		targetAreaList[currentActivatedArea].SetActive(true);
	}
}
