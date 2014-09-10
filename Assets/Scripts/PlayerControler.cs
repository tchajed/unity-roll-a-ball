using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControler : MonoBehaviour {

	public float speed = 500.0f;
	public Text countText;
	public Text winText;

	private int count;

	private void UpdateText() {
		countText.text = "Count: " + count.ToString ();
		if (count < 12) {
			winText.text = "";
		} else {
			winText.text = "You Win!";
		}
	}

	void Start() {
		count = 0;
		UpdateText();
	}

	// Called before physics calculations.
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rigidbody.AddForce(movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("PickUp")) {
			other.gameObject.SetActive(false);
			count++;
			UpdateText();
		}
	}
}
