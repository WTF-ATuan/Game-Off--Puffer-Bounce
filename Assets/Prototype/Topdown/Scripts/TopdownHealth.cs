using System;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype.Topdown{
	public class TopdownHealth : MonoBehaviour{
		public int baseHealth = 5;
		private int _currentHealth;
		[SerializeField] private Image healthIcon;
		[SerializeField] private HorizontalLayoutGroup healthGroup;
		private ColdDownTimer _protectionTimer;

		private void Start(){
			_currentHealth = baseHealth + GameStateManager.StateManager.PlayerData.AdditionHealth;
			UpdateHealthUI();
			_protectionTimer = new ColdDownTimer(0.5f);
		}

		private void UpdateHealthUI(){
			var iconCount = healthGroup.transform.childCount;
			if(_currentHealth == iconCount){
				return;
			}

			if(_currentHealth > iconCount){
				for(var i = iconCount; i < _currentHealth; i++){
					Instantiate(healthIcon, healthGroup.transform);
				}
			}

			if(_currentHealth < iconCount){
				for(var i = iconCount - 1; i >= _currentHealth; i--){
					Destroy(healthGroup.transform.GetChild(i).gameObject);
				}
			}
		}

		private void OnTriggerEnter2D(Collider2D col){
			if(!col.gameObject.CompareTag("Enemy")) return;
			if(!_protectionTimer.CanInvoke()) return;
			_protectionTimer.Reset();
			col.gameObject.GetComponent<TopdownEnemy>()?.Hit();
			_currentHealth -= 1;
			GameStateManager.StateManager.audioManger.PlaySfx(AudioManager.AudioType.PlayerHurt);
			if(_currentHealth < 1){
				GameStateManager.StateManager.ModifyState(GameState.Defeated);
				GameStateManager.StateManager.audioManger.PlaySfx(AudioManager.AudioType.Defeated);
				return;
			}

			UpdateHealthUI();
		}
	}
}