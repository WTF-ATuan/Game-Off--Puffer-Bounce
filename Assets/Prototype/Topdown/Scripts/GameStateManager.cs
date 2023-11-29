using UnityEngine;
using UnityEngine.Serialization;

namespace Prototype.Topdown{
	public class GameStateManager : MonoBehaviour{
		public static GameStateManager StateManager;

		private void Awake(){
			DontDestroyOnLoad(this);
			if(StateManager == null){
				StateManager = this;
			}
		}

		public void ModifyState(GameState state, int id = 0){ }
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
	}

	[CreateAssetMenu(menuName = "GameState/GameData", fileName = "StateData")]
	public class GameStateData : ScriptableObject{
		[SerializeField] private SceneReference battleScene;
	}
}