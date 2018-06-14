using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour {

	List<GameObject> targetAreaList = new List<GameObject>();
	int currentActivatedAreaIndex = 0;

	private void Start(){
		Transform[] targetAreas = GetComponentsInChildren<Transform>(true);
		foreach(Transform currentArea in targetAreas){
			GameObject nextChild = currentArea.gameObject;
			if(nextChild.CompareTag("TargetArea")){
				targetAreaList.Add(nextChild);
			}
		}
		targetAreaList[0].SetActive(true);
	}

	public void nextTarget(){
		targetAreaList[currentActivatedAreaIndex].SetActive(false);
		currentActivatedAreaIndex++;
		targetAreaList[currentActivatedAreaIndex].SetActive(true);
	}

	public GameObject getCurrentTargetArea(){
		return targetAreaList[currentActivatedAreaIndex];
	}
}
