using System;
using UnityEngine;

namespace Prototype.Topdown{
	public class TopdownEnemy : MonoBehaviour{
		[SerializeField] private int hp = 2;
		[SerializeField] private int moveSpeed = 3;
		private Rigidbody2D _rigidbody;
		public Action<TopdownEnemy> OnEnemyGetKill;


		private void Start(){
			_rigidbody = GetComponent<Rigidbody2D>();
		}


		public void Hit(){
			hp--;
			_rigidbody.AddForce(-_rigidbody.velocity, ForceMode2D.Impulse);
			if(hp > 0) return;
			OnEnemyGetKill?.Invoke(this);
		}

		public void FollowingTarget(Vector2 position){
			var direction = (position - (Vector2)transform.position).normalized;
			var movePosition = _rigidbody.position + direction * (moveSpeed * Time.fixedDeltaTime);
			_rigidbody.MovePosition(movePosition);
		}
	}
}