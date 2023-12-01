using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Topdown{
	[CreateAssetMenu(menuName = "GameState/GameData", fileName = "StateData")]
	public class GameStateData : ScriptableObject{
		public SceneObject mainMenu;
		public SceneObject creditScene;
		public SceneObject battleScene;
		public SceneObject shopScene;
		public List<SceneObject> cutscenes;
	}

	[System.Serializable]
	public class BattleSetting{
		public int enemyCount;
		public float spawnDuration;
	}
}