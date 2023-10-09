using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public CharacterController characterController;
	public bool hardMode;

	private CameraController cameraController;
	private CollectableController collectableController;
	private UIController UIController;

	private void Awake()
	{
		if (hardMode)
		{
			int startHealth = characterController.MaxHealth / 2;
			characterController.SetHealth(startHealth);
		}
		else
		{
			characterController.SetHealth(characterController.MaxHealth);
		}
	}

	void Start()
    {
		cameraController = new CameraController(transform.Find("Camera").GetComponent<Camera>(), characterController);
		collectableController = new CollectableController(transform.Find("Collectables"), characterController);
		StarController starController = GetComponent<StarController>();
		UIController = new UIController(transform.Find("UI"), characterController, starController);
	}

	private void Update()
	{
		UIController.Update();
	}

	private void LateUpdate()
	{
		cameraController.LateUpdate();
	}
}
