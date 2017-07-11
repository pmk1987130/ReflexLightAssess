using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingUI : MonoBehaviour {
    float speed = 300;
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.back, Time.deltaTime * speed);
	}
}
