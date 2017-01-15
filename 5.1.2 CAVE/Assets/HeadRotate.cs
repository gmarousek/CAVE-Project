using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using getReal3D;

public class HeadRotate : MonoBehaviour {

    public GameObject head;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = head.transform.rotation;
	}
}
