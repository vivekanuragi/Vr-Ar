using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class buttons : MonoBehaviour, IVirtualButtonEventHandler {

	public GameObject leftbtn;
	public GameObject rightbtn;
	public float restPosition = 0f;
	public float pressedPosition = 45f;
	public float hitStrength = 10000f;
	public float flipperDamper =150f;
	HingeJoint hinge;
	// Use this for initialization
	void Start () {
		leftbtn = GameObject.Find ("left");
		leftbtn.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		rightbtn = GameObject.Find ("right");
		rightbtn.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		hinge = GetComponent<HingeJoint> ();
		hinge.useSpring = true;
	}

	public void OnButtonPressed(VirtualButtonBehaviour vb)
	{
		JointSpring spring = new JointSpring ();
		spring.spring = hitStrength;
		spring.damper = flipperDamper;
		spring.targetPosition = pressedPosition;
		hinge.spring = spring;
		hinge.useLimits = true;
	}

	public void OnButtonReleased(VirtualButtonBehaviour vb)
	{
		JointSpring spring = new JointSpring ();
		spring.spring = hitStrength;
		spring.damper = flipperDamper;
		spring.targetPosition = restPosition;
		hinge.spring = spring;
		hinge.useLimits = true;
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
}
