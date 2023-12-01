using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Prototype.Topdown{
	public class TopdownEnemyRoot : MonoBehaviour{
		[SerializeField] private GameObject enemyPrefab;
		[SerializeField] private GameObject healEnemyPrefab;
		[SerializeField] private GameObject coinEnemyPrefab;
		[SerializeField] private Transform player;
		[SerializeField] private float spawnRadius = 5f;
		[SerializeField] private float randomTargetRadius = 0.5f;

		[HideInInspector] public List<TopdownEnemy> enemies = new();
		private readonly List<Vector2> _targetPositionList = new();
		private ColdDownTimer _timer;
		private const float StartSpawnTime = 2;
		private const float RoundTime = 90;
		private float _roundTimer;

		[SerializeField] private TMP_Text timeText;

		private void Start(){
			var battleLevel = GameStateManager.StateManager.PlayerData.BattleLevel;
			Debug.Log($"battleLevel = {battleLevel}");
			var spawnTime = StartSpawnTime;
			for(var i = 0; i < battleLevel; i++){
				spawnTime *= 0.75f;
			}

			_timer = new ColdDownTimer(spawnTime);
			_roundTimer = RoundTime;
			GameStateManager.StateManager.PlayerData.BattleLevel += 1;
		}

		private void FixedUpdate(){
			SetEnemyFollowingTarget();
			UpdateGameTime();
			if(!_timer.CanInvoke()) return;
			SpawnEnemy();
			_timer.Reset();
		}

		private void UpdateGameTime(){
			_roundTimer -= Time.fixedDeltaTime;
			var minutes = Mathf.FloorToInt(_roundTimer / 60f);
			var seconds = Mathf.FloorToInt(_roundTimer % 60f);

			timeText.text = $"{minutes:00}:{seconds:00}";
			if(_roundTimer < 0){
				GameStateManager.StateManager.ModifyState(GameState.Victory);
			}
		}

		private void SetEnemyFollowingTarget(){
			for(var i = 0; i < enemies.Count; i++){
				var enemy = enemies[i];
				enemy.FollowingTarget(GetTargetPositionByIndex(i));
			}
		}

		private Vector2 GetTargetPositionByIndex(int index){
			if(_targetPositionList.Count - 1 >= index && _targetPositionList[index] != Vector2.zero)
				return _targetPositionList[index] + (Vector2)player.position;
			while(_targetPositionList.Count - 1 < index){
				_targetPositionList.Add(Vector2.zero);
			}

			var randomPosition = Random.insideUnitCircle * randomTargetRadius;
			while(_targetPositionList.Any(x => Vector2.Distance(randomPosition, x) < 0.3f)){
				randomPosition = Random.insideUnitCircle * randomTargetRadius;
			}

			_targetPositionList[index] = randomPosition;
			return _targetPositionList[index] + (Vector2)player.position;
		}

		private void SpawnEnemy(){
			var enemyClone = Instantiate(RandomChooseEnemy(), GetSpawnPosition(), Quaternion.identity);
			var topdownEnemy = enemyClone.GetComponent<TopdownEnemy>();
			topdownEnemy.OnEnemyGetKill += OnEnemyGetKill;
			enemies.Add(topdownEnemy);
		}

		private GameObject RandomChooseEnemy(){
			var range = Random.Range(0, 100);
			return range switch{
				< 70 => enemyPrefab,
				> 70 and < 90 => healEnemyPrefab,
				_ => coinEnemyPrefab
			};
		}

		private void OnEnemyGetKill(TopdownEnemy enemy){
			enemies.Remove(enemy);
			Destroy(enemy.gameObject);
		}


		private void OnDrawGizmos(){
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(player.position, spawnRadius);
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(player.position, randomTargetRadius);
			foreach(var target in _targetPositionList){
				Gizmos.DrawWireCube(target + (Vector2)player.position, Vector3.one * 0.3f);
			}
		}

		private Vector2 GetSpawnPosition(){
			Vector2 center = player.position;
			var randomPosition = Random.insideUnitCircle.normalized * spawnRadius;
			return center + randomPosition;
		}
	}
}