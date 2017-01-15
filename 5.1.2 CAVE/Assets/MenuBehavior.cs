using UnityEngine;
using System.Collections;
using getReal3D;

public class NewBehaviourScript : MonoBehaviour {

    GameObject menu;
    GameObject grabObject;
    public string button = "WandButton";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.parent.position, transform.parent.forward * 2f, Color.yellow);
        if (grabObject == null && getReal3D.Input.GetButtonDown(button))
        {
            RaycastHit hit = new RaycastHit();
            bool hitTest = Physics.Raycast(transform.parent.position, transform.parent.forward, out hit, 2.0f);
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
                switch (grabObject.name)
                {
                    case "Red":
                        break;
                    case "Green":
                        break;
                    case "Blue":
                        break;
                    case "Enlarge":
                        break;
                    case "Done":
                        break;
                }

                //				grabRigidBodyKinematic = grabObject.GetComponent<Rigidbody>().isKinematic;
                //				grabObject.GetComponent<Rigidbody>().isKinematic = true;

                //				m_lastPosition = transform.position;
                //				m_lastOrientation = transform.rotation;
                //				m_velocitySmoothed = m_angularVelocitySmoothed = Vector3.zero;
            }
        }
    }
}
