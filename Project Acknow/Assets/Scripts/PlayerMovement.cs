﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController2D controller2D;

	float HorizontalMove = 0f;
	bool Jump = false;
    bool Crouch = false;
    public float RunSpeed = 40f;

	private void FixedUpdate()
	{
		HorizontalMove = Input.GetAxisRaw("Horizontal") * RunSpeed;
		Jump = Input.GetKey(KeyCode.Space);
		Crouch = Input.GetKey(KeyCode.LeftShift);

		controller2D.Move(HorizontalMove * Time.fixedDeltaTime , Crouch, Jump);
	}
}
