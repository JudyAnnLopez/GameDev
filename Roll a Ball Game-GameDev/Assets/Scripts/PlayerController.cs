 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {


	public float speed;

	private Rigidbody rb;

	public Text countText;

	public Text winText;

	private int count;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();

		countText.text = "Score :";

		winText.text = "";
		
	}


	private void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("Pick Up")) {

			other.gameObject.SetActive (false);

			count = count + 1;
			SetCountText ();


			if (count >= 5) {
				winText.text = "You Won!";
			}

		}
	}
	// Update is called once per frame
	void FixedUpdate () {

		float movementHorizontal = Input.GetAxis("Horizontal");
		float movementVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (movementHorizontal, 0.0f, movementVertical);

		rb.AddForce (movement * speed);

	}

	void SetCountText(){
		countText.text = "Score : " + count.ToString ();
	}

}
