using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRotate : MonoBehaviour {

	private void LateUpdate () {
        transform.Rotate(0, 1, 0, Space.World);
	}
}
