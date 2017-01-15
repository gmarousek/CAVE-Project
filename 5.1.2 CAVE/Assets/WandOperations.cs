using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using getReal3D;

public class WandOperations
	: MonoBehaviour
{
	public string button = "WandButton";
	private GameObject grabObject = null;
	private UnityEngine.Transform grabParent = null;
	private bool grabRigidBodyKinematic = false;
	private Vector3 m_lastPosition = Vector3.zero;
	private Vector3 m_velocity = Vector3.zero;
	private Vector3 m_velocitySmoothed = Vector3.zero;
	private Vector3 m_angularVelocity = Vector3.zero;
	private Quaternion m_lastOrientation = Quaternion.identity;
	private Vector3 m_angularVelocitySmoothed = Vector3.zero;
	public LayerMask grabLayerMask = -1;

	public Slider red;
	public Slider green;
	public Slider blue;
	public Toggle enlarge;
	public float sizerate;
	private bool resizing = false;
	private Vector3 targetSize = Vector3.one;

	void OnDisable()
	{
		DropObject();
	}

	void DropObject()
	{
		if (grabObject != null)
		{
			resizing = false;

//			if (grabObject.activeInHierarchy && grabParent.gameObject.activeInHierarchy)
//				grabObject.transform.parent = grabParent;
//			if (grabObject.GetComponent<Rigidbody>())
//			{
//				grabObject.GetComponent<Rigidbody>().isKinematic = grabRigidBodyKinematic;
//				if (!grabRigidBodyKinematic)
//				{
//					grabObject.GetComponent<Rigidbody>().velocity = m_velocitySmoothed;
//					grabObject.GetComponent<Rigidbody>().angularVelocity = -m_angularVelocitySmoothed;
//				}
//			}
//			grabObject = null;
//			grabParent = null;
		}
	}

	void Update()
	{
		Debug.DrawRay(transform.parent.position, transform.parent.forward * 2f, Color.yellow);
		if (getReal3D.Input.GetButtonUp(button))
		{
			DropObject();
		}
		else if (grabObject == null && getReal3D.Input.GetButtonDown(button))
		{
			RaycastHit hit = new RaycastHit();
			bool hitTest = Physics.Raycast(transform.parent.position, transform.parent.forward, out hit, 2.0f, grabLayerMask);
			if (hitTest)
			{
				Rigidbody rb = hit.rigidbody;
				Transform tf = hit.transform.parent;
				while (rb == null && tf.parent != null)
				{
					tf = tf.parent;
					rb = tf.GetComponent<Rigidbody>();
				}

				if (rb)
					grabObject = rb.gameObject;
				else
					return;

//				grabParent = grabObject.transform.parent;
//				grabObject.transform.parent = transform.parent;
				if (grabObject.tag == "Paintable") {
					grabObject.GetComponent<MeshRenderer>().material.color = new Color (
						this.red.value, this.green.value, this.blue.value);
					resizing = true;
					grabObject.transform.localScale = Vector3.Lerp(
						grabObject.transform.localScale, targetSize, sizerate * Time.deltaTime);
				}
				else
				{
					resizing = false;
				}

				if (resizing) {
					if (enlarge.isOn) {
						float x = targetSize.x + 0.1f;
						float y = targetSize.x + 0.1f;
						float z = targetSize.x + 0.1f;
						targetSize = new Vector3 (x, y, z);
					} else {
						float x = targetSize.x - 0.1f;
						float y = targetSize.x - 0.1f;
						float z = targetSize.x - 0.1f;
						targetSize = new Vector3 (x, y, z);
					}
				}

//				grabRigidBodyKinematic = grabObject.GetComponent<Rigidbody>().isKinematic;
//				grabObject.GetComponent<Rigidbody>().isKinematic = true;

//				m_lastPosition = transform.position;
//				m_lastOrientation = transform.rotation;
//				m_velocitySmoothed = m_angularVelocitySmoothed = Vector3.zero;
			}
		}
		else if (grabObject != null)
		{

			if (grabObject.tag == "Paintable") {
				grabObject.GetComponent<MeshRenderer>().material.color = new Color (
					this.red.value, this.green.value, this.blue.value);
				resizing = true;
				grabObject.transform.localScale = Vector3.Lerp(
					grabObject.transform.localScale, targetSize, sizerate * Time.deltaTime);
			}
			else
			{
				resizing = false;
			}

			if (resizing) {
				if (enlarge.isOn) {
					float x = targetSize.x + 0.1f;
					float y = targetSize.x + 0.1f;
					float z = targetSize.x + 0.1f;
					targetSize = new Vector3 (x, y, z);
				} else {
					float x = targetSize.x - 0.1f;
					float y = targetSize.x - 0.1f;
					float z = targetSize.x - 0.1f;
					targetSize = new Vector3 (x, y, z);
				}
			}

//			trackVelocity();
		}
	}

//	private Vector3 CalculateAngularVelocity(Quaternion prev, Quaternion current)
//	{
//		Quaternion deltaRotation = Quaternion.Inverse(prev) * current;
//		float angle = 0.0f;
//		Vector3 axis = Vector3.zero;
//		deltaRotation.ToAngleAxis(out angle, out axis);
//		if (axis == Vector3.zero || axis.x == Mathf.Infinity || axis.x == Mathf.NegativeInfinity)
//			axis = Vector3.zero;
//		if (angle >  180) angle -= 360;
//		if (angle < -180) angle += 360;
//		return axis.normalized * angle / Time.smoothDeltaTime;
//	}
//
//	private void trackVelocity()
//	{
//		m_velocity = (transform.position - m_lastPosition) / Time.smoothDeltaTime;
//		m_velocitySmoothed = Vector3.Lerp(m_velocitySmoothed, m_velocity, Time.smoothDeltaTime * 10);
//
//		m_angularVelocity = CalculateAngularVelocity(m_lastOrientation, transform.rotation);
//		m_angularVelocitySmoothed = Vector3.Lerp(m_angularVelocitySmoothed, m_angularVelocity, Time.smoothDeltaTime * 3);
//
//		m_lastPosition = transform.position;
//		m_lastOrientation = transform.rotation;
//	}
}