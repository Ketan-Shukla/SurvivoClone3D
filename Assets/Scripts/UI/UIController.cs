using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController
{
	private CharacterController characterController;
	private StarController starController;

	private Image healthSlider;
	private TextMeshProUGUI healthText;
	private TextMeshProUGUI starText;

	public UIController(Transform UIRoot, CharacterController characterController,
		StarController starController)
	{
		this.characterController = characterController;
		this.starController = starController;

		healthSlider = UIRoot.Find("HealthBar/BarFill").GetComponent<Image>();
		healthText = UIRoot.Find("HealthBar/Text").GetComponent<TextMeshProUGUI>();
		starText = UIRoot.Find("ScoreCount/Background/Text").GetComponent<TextMeshProUGUI>();
	}

	public void Update()
	{
		healthSlider.fillAmount = (float)characterController.Health / characterController.MaxHealth;
		healthText.text = characterController.Health + "/" + characterController.MaxHealth;
		starText.text = starController.Star.ToString();
	}
}
