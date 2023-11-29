using System;
using UnityEngine;

namespace Prototype.Topdown{
	public class TopdownEnemy : MonoBehaviour{
		[SerializeField] private int hp = 2;
		[SerializeField] private int moveSpeed = 3;
		private Rigidbody2D _rigidbody;
		public Action<TopdownEnemy> OnEnemyGetKill;
		private float _movementPercent = 1;

		private void Start(){
			_rigidbody = GetComponent<Rigidbody2D>();
		}


		public void Hit(){
			hp -= 1;
			_movementPercent *= 0.75f;
			if(hp > 0) return;
			OnEnemyGetKill?.Invoke(this);
		}

		public void FollowingTarget(Vector2 position){
			var direction = (position - (Vector2)transform.position).normalized;
			_rigidbody.velocity = direction * (moveSpeed * _movementPercent);
			HandleFaceDirection();
		}

		private void HandleFaceDirection(){
			if(_rigidbody.velocity.x == 0){
				return;
			}

			var scale = transform.localScale;
			var originScale = Mathf.Abs(scale.x);
			transform.localScale = _rigidbody.velocity.x > 0
					? new Vector3(-originScale, scale.y, scale.z)
					: new Vector3(originScale, scale.y, scale.z);
		}
	}
}