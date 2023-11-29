using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Prototype.Topdown{
	[CreateAssetMenu(menuName = "GameState/GameData", fileName = "StateData")]
	public class GameStateData : ScriptableObject{
		public SceneObject battleScene;
		public List<BattleSetting> battleSettings = new();
		public SceneObject shopScene;
		public SceneObject bossScene;
		public List<SceneObject> cutscenes;
	}

	[System.Serializable]
	public class BattleSetting{
		public int enemyCount;
		public float spawnDurationRandomMax = 5;
		public float spawnDurationRandomMin = 0.5f;
	}
}