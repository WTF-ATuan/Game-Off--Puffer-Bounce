using System;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype.Topdown{
	public class TopdownEnergy : MonoBehaviour{
		public int baseEnergy = 5;
		private int _currentEnergy;
		private int _energyMax;
		[SerializeField] private Image energyIcon;
		[SerializeField] private HorizontalLayoutGroup energyGroup;

		private void Start(){
			_energyMax = baseEnergy + GameStateManager.StateManager.PlayerData.AdditionEnergyMax;
			_currentEnergy = _energyMax;
			UpdateHealthUI();
		}

		public bool CheckEnergyCost(int amount){
			return _currentEnergy - amount >= 0;
		}

		public void UseEnergy(int amount){
			_currentEnergy -= amount;
			UpdateHealthUI();
		}

		private void UpdateHealthUI(){
			var iconCount = energyGroup.transform.childCount;
			if(_currentEnergy == iconCount){
				return;
			}

			if(_currentEnergy > iconCount){
				for(var i = iconCount; i < _currentEnergy; i++){
					Instantiate(energyIcon, energyGroup.transform);
				}
			}

			if(_currentEnergy < iconCount){
				for(var i = iconCount - 1; i >= _currentEnergy; i--){
					Destroy(energyGroup.transform.GetChild(i).gameObject);
				}
			}
		}

		private void OnTriggerEnter2D(Collider2D col){
			if(!col.gameObject.CompareTag("Pickable")){
				return;
			}

			var objName = col.name;
			switch(objName){
				case "Coin":
					GameStateManager.StateManager.PlayerData.Coins++;
					break;
				case "Energy scale":
					_currentEnergy += 1;
					if(_currentEnergy >= _energyMax){
						_currentEnergy = _energyMax;
					}

					UpdateHealthUI();

					break;
				case "Health Coin":
					GameStateManager.StateManager.PlayerData.HealthCoins++;
					break;
			}

			GameStateManager.StateManager.audioManger.PlaySfx(AudioManager.AudioType.CollectItems);
			Destroy(col.gameObject);
		}
	}
}