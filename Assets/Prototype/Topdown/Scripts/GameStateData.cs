using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Topdown{
	[CreateAssetMenu(menuName = "GameState/GameData", fileName = "StateData")]
	public class GameStateData : ScriptableObject{
		public SceneObject battleScene;
		public SceneObject shopScene;
		public SceneObject bossScene;
		public List<SceneObject> cutscenes;
	}

	[System.Serializable]
	public class BattleSetting{
		public int enemyCount;
		public float spawnDuration;
	}
}