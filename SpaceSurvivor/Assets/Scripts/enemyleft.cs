using UnityEngine;
using System.Collections;

public class enemyleft : MonoBehaviour {

	// Use this for initialization
	public float moveSpeed = 2.0f;

	float moveDirection = 1.0f;
	Vector3 moveAmount;
 // Update is called once per frame





	void Update () {
		moveAmount.x = moveDirection * moveSpeed * Time.deltaTime;
        moveDirection = -1.0f;
		transform.Translate(moveAmount);
		
 }
}
