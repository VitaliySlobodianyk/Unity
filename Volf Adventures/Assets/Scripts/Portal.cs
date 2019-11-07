using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
	public GameObject _portal;
    public GameObject splash;
	void Update () {
		_portal.transform.Rotate (new Vector3 (0f, 0f, 3f));
	}
}
