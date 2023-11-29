using System;
using UnityEngine;

namespace Prototype.Topdown{
	public class TopdownEnemy : MonoBehaviour{
		[SerializeField] private int hp = 2;
		[SerializeField] private int moveSpeed = 3;
		[HideInInspector] public Transform playerTransform;
		private Rigidbody2D _rigidbody;


		private void Start(){
			_rigidbody = GetComponent<Rigidbody2D>();
		}


		public void Hit(){
			hp--;
			if(hp <= 0) Destroy(gameObject);
		}

		private void Update(){
			Movement();
		}

		private void Movement(){
			Vector2 direction = (playerTransform.position - transform.position).normalized;
			var movePosition = _rigidbody.position + direction * (moveSpeed * Time.fixedDeltaTime);

			_rigidbody.MovePosition(movePosition);
		}
	}
}