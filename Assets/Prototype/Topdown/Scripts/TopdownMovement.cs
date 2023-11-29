using System;
using UnityEngine;

namespace Prototype.Topdown{
	public class TopdownMovement : MonoBehaviour{
		[SerializeField] private float moveSpeed = 5;


		private Rigidbody2D _rigidbody;
		private Vector2 _moveValue;
		private bool _jump;

		private void Start(){
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		private void Update(){
			_moveValue = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
			_jump = Input.GetButtonDown("Jump");
			HandleDash();
		}

		private void FixedUpdate(){
			HandleMove();
			HandleFaceDirection();
		}

		private void HandleDash(){
			if(!_jump) return;
			_rigidbody.AddForce(_moveValue * 5 , ForceMode2D.Impulse);
		}

		private void HandleFaceDirection(){
			if(_rigidbody.velocity.x == 0){
				return;
			}

			var scale = transform.localScale;
			var originScale = Mathf.Abs(scale.x);
			transform.localScale = _rigidbody.velocity.x > 0
					? new Vector3(originScale, scale.y, scale.z)
					: new Vector3(-originScale, scale.y, scale.z);
		}

		private void HandleMove(){
			if(_moveValue.magnitude == 0){
				var rigidbodyVelocity = _rigidbody.velocity;
				rigidbodyVelocity.x = Mathf.MoveTowards(rigidbodyVelocity.x, 0, 20 * Time.fixedDeltaTime);
				rigidbodyVelocity.y = Mathf.MoveTowards(rigidbodyVelocity.y, 0, 20 * Time.fixedDeltaTime);
				_rigidbody.velocity = rigidbodyVelocity;
			}
			else{
				var rigidbodyVelocity = _rigidbody.velocity;
				rigidbodyVelocity.x =
						Mathf.MoveTowards(rigidbodyVelocity.x, _moveValue.x * moveSpeed, 10 * Time.fixedDeltaTime);
				rigidbodyVelocity.y =
						Mathf.MoveTowards(rigidbodyVelocity.y, _moveValue.y * moveSpeed, 10 * Time.fixedDeltaTime);
				_rigidbody.velocity = rigidbodyVelocity;
			}
		}
	}
}