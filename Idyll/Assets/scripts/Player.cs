using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private Rigidbody2D myRigidbody;

	public Transform transformLoc;
	public Transform transformLoc2;
	public Transform transformLoc3;

	[SerializeField]
	private float movementSpeed;

	private Animator myAnimator;

	private bool facingRight;


	public GameObject player;
	// Use this for initialization
	void Start () 
	{
		facingRight = false;
		myRigidbody = GetComponent<Rigidbody2D> ();
		myAnimator = GetComponent<Animator> ();

	}

	// Update is called once per frame
	public IEnumerator nextPlane(Vector3 pos){

		Vector3 newPos = new Vector3 (pos.x, pos.y, player.transform.position.z);
		yield return new WaitForSeconds (0.5f);
		player.transform.position = newPos;

	}

	void Update () {

		float horizontal = Input.GetAxis ("Horizontal");
		HandleMovement (horizontal);

		if (Input.GetKeyDown ("space")) {
			Debug.Log ("Going up!");
			StartCoroutine (nextPlane(transformLoc.transform.position));
		}

		Flip (horizontal);
	}



	private void HandleMovement(float horizontal)
	{
		myRigidbody.velocity = new Vector2(horizontal * movementSpeed,myRigidbody.velocity.y); //x = -1, y = 0;

		myAnimator.SetFloat ("speed", Mathf.Abs (horizontal));
	}

	private void Flip(float horizontal)
	{
		if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
		{
			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;

			theScale.x *= -1;

			transform.localScale = theScale;
		}
	}
}