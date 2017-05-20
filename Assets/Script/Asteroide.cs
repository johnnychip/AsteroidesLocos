using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour {

	private Transform[] path = new Transform[4];

	private int currentWayPoint;

	private float elapsedTime;

	[SerializeField]
	private float timePath;

	private bool isRunnig;
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (!isRunnig)
			return;

		elapsedTime += Time.deltaTime;
		Vector3 currentPosition = Vector3.Lerp (transform.position, path [currentWayPoint].position, elapsedTime / timePath);
		transform.position = currentPosition;
		if (elapsedTime >= timePath) {
			elapsedTime = 0f;
			currentWayPoint++;

			if (currentWayPoint >= path.Length) {
				isRunnig = false;
				gameObject.SetActive (false);
			}
		}

	}

	public void SetPath(Transform[] path)
	{
		this.path = path;
		transform.position = path [0].position;
		isRunnig = true;
	}
}
