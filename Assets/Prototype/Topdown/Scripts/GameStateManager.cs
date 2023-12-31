﻿using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Prototype.Topdown{
	public class GameStateManager : MonoBehaviour{
		[SerializeField] private GameStateData gameData;
		public AudioManager audioManger;
		public static GameStateManager StateManager;

		public PlayerData PlayerData;

		public UnityEvent onVictory;
		public UnityEvent onDefeated;
		public OnClickEvent onNextEvent;

		public bool cheatMode;

		private void Update(){
			if(!cheatMode) return;
			if(Input.GetKeyDown(KeyCode.Space)){
				PlayerData.Coins += 100;
				PlayerData.HealthCoins += 100;
			}
		}

		private void Awake(){
			if(StateManager != null && StateManager != this){
				Destroy(gameObject);
			}
			else{
				StateManager = this;
			}

			DontDestroyOnLoad(this);
			PlayerData = new PlayerData();
		}


		public void ModifyState(GameState state, int id = 0){
			switch(state){
				case GameState.CutScene:
					Time.timeScale = 1;
					ChangeToCutScene(id);
					break;
				case GameState.Tutorial:
					break;
				case GameState.GamePlay:
					Time.timeScale = 1;
					ChangeToGamePlayScene(id);
					break;
				case GameState.Shop:
					Time.timeScale = 1;
					SceneManager.LoadScene(gameData.shopScene.ToString());
					break;
				case GameState.Defeated:
					onDefeated?.Invoke();
					onNextEvent.onClick.AddListener(() => ModifyState(GameState.MainMenu));
					PlayerData = new PlayerData();
					Time.timeScale = 0;
					break;

				case GameState.Victory:
					onVictory?.Invoke();
					onNextEvent.onClick.AddListener(() => ModifyState(GameState.Shop));
					Time.timeScale = 0;
					break;

				case GameState.MainMenu:
					SceneManager.LoadScene(gameData.mainMenu.ToString());
					break;
				case GameState.Credit:
					SceneManager.LoadScene(gameData.creditScene.ToString());
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(state), state, null);
			}
		}

		private void ChangeToGamePlayScene(int level){
			var sceneName = gameData.battleScene.ToString();
			SceneManager.LoadScene(sceneName);
		}

		private void ChangeToCutScene(int stage){
			var sceneName = gameData.cutscenes[stage].ToString();
			SceneManager.LoadScene(sceneName);
		}
	}

	public enum GameState{
		CutScene,
		Tutorial,
		GamePlay,
		Defeated,
		Victory,
		Shop,
		MainMenu,
		Credit,
	}

	public class PlayerData{
		public int Coins;
		public int HealthCoins;
		public int BattleLevel;

		public int AdditionHealth = 0;
		public int AdditionEnergyMax = 0;
		public int AdditionShootCount = 0;
		public int AdditionUltCount = 0;
	}
}