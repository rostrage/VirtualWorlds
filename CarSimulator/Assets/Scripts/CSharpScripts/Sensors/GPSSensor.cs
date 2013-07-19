using UnityEngine;
using System.Collections;

public class GPSSensor : CarSensor {
	Transform theTransform;
	void Start() {
		theTransform = transform;
		Vector3 target = GameObject.Find("Node1").transform.position;
		dataThisFrame["TargetX"] = target.x;
		dataThisFrame["TargetY"] = target.y;
		dataThisFrame["TargetZ"] = target.z;
	}
	
	void Update () {
		dataThisFrame["PositionX"] = theTransform.position.x;
		dataThisFrame["PositionY"] = theTransform.position.y;
		dataThisFrame["PositionZ"] = theTransform.position.z;
		dataThisFrame["ForwardX"] = theTransform.forward.x;
		dataThisFrame["ForwardY"] = theTransform.forward.y;
		dataThisFrame["ForwardZ"] = theTransform.forward.z;
		
	}
	
	void OnTriggerEnter(Collider theCollision) {
		Vector3 newTarget = theCollision.GetComponent<RoadNode>().nextNode.transform.position;
		Debug.Log("New target");
		Debug.Log(newTarget);
		dataThisFrame["TargetX"] = newTarget.x;
		dataThisFrame["TargetY"] = newTarget.y;
		dataThisFrame["TargetZ"] = newTarget.z;
	}
}
