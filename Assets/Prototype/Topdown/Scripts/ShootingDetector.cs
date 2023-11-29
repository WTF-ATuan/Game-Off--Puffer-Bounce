using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Prototype.Topdown{
	public class ShootingDetector : MonoBehaviour{
		private CircleCollider2D _circleCollider;
		private ShootingScale _shootingScale;
		private readonly List<Transform> _enemyAroundList = new();

		private void Start(){
			_circleCollider = GetComponent<CircleCollider2D>();
			_shootingScale = GetComponent<ShootingScale>();
		}

		private void Update(){
			DetectingEnemy();
			_shootingScale.target = GetCloseEnemy();
		}

		private void DetectingEnemy(){
			var center = _circleCollider.bounds.center;
			// ReSharper disable once Unity.PreferNonAllocApi
			var hits = Physics2D.CircleCastAll(center, _circleCollider.radius, Vector2.zero);
			_enemyAroundList.Clear();
			foreach(var hit in hits){
				if(!hit.transform.CompareTag($"Enemy")) continue;
				_enemyAroundList.Add(hit.transform);
			}
		}

		private Transform GetCloseEnemy(){
			return _enemyAroundList
					.OrderBy(enemy => Vector3.Distance(transform.position, enemy.transform.position))
					.FirstOrDefault();
		}

		private void OnDrawGizmos(){
			if(_enemyAroundList.Count < 1) return;
			Gizmos.color = Color.yellow;
			foreach(var enemy in _enemyAroundList){
				Gizmos.DrawWireCube(enemy.position, enemy.localScale);
			}
		}
	}
}