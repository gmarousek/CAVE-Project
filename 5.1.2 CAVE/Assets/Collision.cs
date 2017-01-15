using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Collision : MonoBehaviour {
	public Slider red;
	public Slider green;
	public Slider blue;
	public Toggle enlarge;
	public float sizerate;
	// Use this for initialization
	void Start () {
		red.value = 0.5f;
		green.value = 0.1f;
		blue.value = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Paintable") {
			Debug.Log ("setting it");
			other.GetComponent<MeshRenderer> ().material.color = new Color (red.value, green.value, blue.value);
			if (enlarge.isOn)
				other.transform.localScale = Vector3.one * sizerate;
			else
				other.transform.localScale = Vector3.one / sizerate;
		}
	}
}
