using System;
using UnityEngine;

namespace Prototype.Topdown{
	public class TopdownEnemyRoot : MonoBehaviour{
		[SerializeField] private GameObject enemyPrefab;
		[SerializeField] private Transform player;
		[SerializeField] private float spawnDuration = 1f;

		private ColdDownTimer _timer;

		private void Start(){
			_timer = new ColdDownTimer(spawnDuration);
		}

		private void FixedUpdate(){
			if(!_timer.CanInvoke()) return;
			SpawnEnemy();
			_timer.Reset();
		}

		private void SpawnEnemy(){
			var enemyClone = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
			enemyClone.GetComponent<TopdownEnemy>().playerTransform = player;
		}


		private void OnDrawGizmos(){
			Gizmos.color = Color.red;
			Gizmos.DrawWireCube(transform.position, Vector2.one * 0.5f);
		}
	}
}