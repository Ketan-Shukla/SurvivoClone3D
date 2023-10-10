using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CameraController
{
	private const float FOLLOW_DIST_BACK = -5f;
	private const float FOLLOW_DIST_UP = 20f;
	private Transform cameraTrans;
	private CharacterController character;

	public CameraController(Camera camera, CharacterController character)
	{
		this.cameraTrans = camera.transform;
		this.character = character;
	}

	public void LateUpdate()
	{
		cameraTrans.position= new Vector3(character.transform.position.x, character.transform.position.y + FOLLOW_DIST_UP, character.transform.position.z + FOLLOW_DIST_BACK);
		cameraTrans.LookAt(character.transform);
	}
}
