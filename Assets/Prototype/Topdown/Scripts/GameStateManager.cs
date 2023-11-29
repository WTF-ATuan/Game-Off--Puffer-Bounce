using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototype.Topdown{
	public class GameStateManager : MonoBehaviour{
		public static GameStateManager StateManager;
		public PlayerData PlayerData;
		[SerializeField] private GameStateData gameData;


		private void Awake(){
			DontDestroyOnLoad(this);
			if(StateManager == null){
				StateManager = this;
			}
		}

		public void ModifyState(GameState state, int id = 0){
			if(state == GameState.GamePlay){
				ChangeToGamePlayScene(id);
			}
		}

		private void ChangeToGamePlayScene(int level){
		}
	}

	public enum GameState{
		CutScene,
		Tutorial,
		GamePlay,
		Shop,
		BossFight
	}

	public class PlayerData{
		public int Coins;
		public int BattleLevel;
	}
}