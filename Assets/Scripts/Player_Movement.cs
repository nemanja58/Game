using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I did not get instructions do i build mobile or PC version so the movement is made for PC
public class Player_Movement : MonoBehaviour
{
	public float speed =2f;
	public float runSpeed;
	public Animator animator;

	


	private Vector3 touchStartPosition;
	

	private void Update()
	{
		//Did not have time to thest--->
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began)
			{
				touchStartPosition = touch.position;
			}

			if (touch.phase == TouchPhase.Moved)
			{
				Vector3 currentTouchPosition = touch.position;
				Vector3 delta = currentTouchPosition - touchStartPosition;
				transform.position += new Vector3(delta.x, delta.y, 0);
				touchStartPosition = currentTouchPosition;
			}
		}

		//<--- this code
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		Vector3 direction = new Vector3(horizontal, vertical, 0);
	
		bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
		float currentSpeed = isRunning ? runSpeed : speed;

		AnimateMovement(direction);
		transform.position += direction * currentSpeed * Time.deltaTime;
		//Debug.Log(isRunning);

		if (Mathf.Abs(horizontal) > 0.1f)
		{
			// Set the character's rotation based on the sign of the horizontal input
			float rotationY = Mathf.Sign(horizontal) == 1 ? 0 : 180;
			transform.rotation = Quaternion.Euler(0, rotationY, 0);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			// Call the Attack method when the user presses the spacebar
			Attack();
		}

	}

	void AnimateMovement(Vector3 direction)
	{
		if (animator != null)
		{
			if (direction.magnitude > 0)
			{
				Debug.Log("test1");
				animator.SetBool("IsMoving", true);
				animator.SetFloat("Horizontal", direction.x);
				animator.SetFloat("Vertical", direction.y);
				if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
				{
					animator.SetTrigger("Run");
					Debug.Log("Triggering run animation");
				}
			}
			else
			{
				animator.SetBool("IsMoving", false);
				animator.SetBool("Run", false);
			}
		}
	}

	

	public void Attack()
	{
		// Trigger the "Attack" parameter in the Animator component
		animator.SetTrigger("Attack 0");
	}




}
