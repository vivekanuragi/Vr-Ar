﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class khiladi : MonoBehaviour {
	public Text countText;
	public Text WinText;

	private Rigidbody rb;
	private int count;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		WinText.text = "";

	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("pickups"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();

		}
	}
	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 9)
		{
			WinText.text = "You Win!";
	}

}
}
