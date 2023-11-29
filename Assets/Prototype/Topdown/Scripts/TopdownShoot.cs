using System;
using UnityEngine;

namespace Prototype.Topdown{
	public class TopdownShoot : MonoBehaviour{
		[SerializeField] private GameObject scaleBullet;
		[SerializeField] private int scaleCount = 6;
		[SerializeField] private int fireRange = 3;

		private Camera _mainCamera;

		private void Start(){
			_mainCamera = Camera.main;
		}

		private void Update(){
			if(Input.GetMouseButtonDown(0)){
				Shoot(GetMouseDirection());
			}

			if(Input.GetMouseButtonDown(1)){
				Spray();
			}
		}

		private void Spray(){
			var additionAngle = 360 / scaleCount;
			for(var i = 0; i < scaleCount; i++){
				var angle = additionAngle * i;
				var position = transform.position;
				var x = position.x + Mathf.Cos(angle * Mathf.Deg2Rad);
				var y = position.y + Mathf.Sin(angle * Mathf.Deg2Rad);
				var bulletClone = Instantiate(scaleBullet, new Vector3(x, y, 0), Quaternion.identity);
				var bulletClonePosition = bulletClone.transform.position;
				var directionToCenter = (position - bulletClonePosition).normalized;
				var angleToCenter = Mathf.Atan2(directionToCenter.y, directionToCenter.x) * Mathf.Rad2Deg;
				bulletClone.transform.rotation = Quaternion.Euler(0, 0, angleToCenter + 90);
				bulletClone.GetComponent<Rigidbody2D>().AddForce((bulletClonePosition - position).normalized * 10,
					ForceMode2D.Impulse);
			}
		}

		private void Shoot(Vector3 direction){
			var bulletClone = Instantiate(scaleBullet, transform.position + direction * fireRange, Quaternion.identity);
			bulletClone.transform.up = direction;
			bulletClone.GetComponent<Rigidbody2D>().AddForce(direction * 10, ForceMode2D.Impulse);
		}

		private Vector3 GetMouseDirection(){
			var mousePosition = Input.mousePosition;
			mousePosition.z = -10;
			var mouseWorldPosition = _mainCamera.ScreenToWorldPoint(mousePosition);
			var direction = (transform.position - mouseWorldPosition).normalized;
			direction.z = 0;
			direction = direction.normalized;
			return direction;
		}

		private void OnDrawGizmos(){
			if(!Application.isPlaying){
				return;
			}

			Gizmos.color = Color.red;
			var position = transform.position;
			Gizmos.DrawLine(position, position + GetMouseDirection() * fireRange);
		}
	}
}