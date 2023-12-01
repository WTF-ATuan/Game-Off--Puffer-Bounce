﻿using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype.Topdown{
	public class ShopManager : MonoBehaviour{
		[SerializeField] private Button energyUpgrade;
		[SerializeField] private TMP_Text energyCost;
		[SerializeField] private Button shootingUpgrade;
		[SerializeField] private TMP_Text shootingCost;
		[SerializeField] private Button ultUpgrade;
		[SerializeField] private TMP_Text ultCost;
		[SerializeField] private Button healthUpgrade;
		[SerializeField] private TMP_Text healthCost;

		[SerializeField] private TMP_Text message;


		private void Start(){
			energyUpgrade.onClick.AddListener(UpgradeEnergy);
			ultUpgrade.onClick.AddListener(UpgradeUlt);
			healthUpgrade.onClick.AddListener(UpdateHealth);
		}

		private void UpdateHealth(){
			if(GameStateManager.StateManager.PlayerData.HealthCoins < int.Parse(healthCost.text)){
				Message("You don,t have enough health coin");
				return;
			}

			GameStateManager.StateManager.PlayerData.HealthCoins -= int.Parse(healthCost.text);
			GameStateManager.StateManager.PlayerData.AdditionHealth += 1;
			var nextPrice = 3 * (int)Mathf.Pow(2, GameStateManager.StateManager.PlayerData.AdditionHealth - 1);
			healthCost.text = nextPrice.ToString();
			Message("Success! Oh yeah");
		}

		private void UpgradeUlt(){
			if(!CheckPlayerCoin(int.Parse(ultCost.text))){
				Message("You don,t have enough coins");
				return;
			}

			GameStateManager.StateManager.PlayerData.Coins -= int.Parse(ultCost.text);
			GameStateManager.StateManager.PlayerData.AdditionUltCount += 1;
			var nextPrice = 7 * (int)Mathf.Pow(2, GameStateManager.StateManager.PlayerData.AdditionUltCount - 1);
			ultCost.text = nextPrice.ToString();
			Message("Success! Oh yeah");
		}

		private void UpgradeEnergy(){
			if(!CheckPlayerCoin(int.Parse(energyCost.text))){
				Message("You don,t have enough coins");
				return;
			}

			GameStateManager.StateManager.PlayerData.Coins -= int.Parse(energyCost.text);
			GameStateManager.StateManager.PlayerData.AdditionEnergyMax += 1;
			var nextPrice = 5 * (int)Mathf.Pow(2, GameStateManager.StateManager.PlayerData.AdditionEnergyMax - 1);
			energyCost.text = nextPrice.ToString();
			Message("Success! Oh yeah");
		}

		private void Message(string text, float duration = 2f){
			message.DOFade(1, 0);
			message.text = text;
			message.DOFade(0, duration);
		}

		private bool CheckPlayerCoin(int amount){
			return GameStateManager.StateManager.PlayerData.Coins > amount;
		}
	}
}