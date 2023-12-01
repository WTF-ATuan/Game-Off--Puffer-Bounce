using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Prototype.Topdown{
	public class TopdownShoot : MonoBehaviour{
		[SerializeField] private GameObject scaleBullet;
		[SerializeField] private int ultScaleCount = 5;
		[SerializeField] private int shootScaleCount = 1;
		[SerializeField] private int fireRange = 3;

		private Camera _mainCamera;
		private TopdownEnergy _energy;

		private void Start(){
			_mainCamera = Camera.main;
			_energy = GetComponent<TopdownEnergy>();
			var playerData = GameStateManager.StateManager.PlayerData;
			ultScaleCount += playerData.AdditionUltCount;
			shootScaleCount += playerData.AdditionShootCount;
		}

		private void Update(){
			if(Input.GetMouseButtonDown(0)){
				Shoot(GetMouseDirection());
			}

			if(Input.GetMouseButtonDown(1) && _energy.CheckEnergyCost(3)){
				Spray();
				_energy.UseEnergy(3);
			}
		}

		private void Spray(){
			var additionAngle = 360 / ultScaleCount;
			for(var i = 0; i < ultScaleCount; i++){
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

			GameStateManager.StateManager.audioManger.PlaySfx(AudioManager.AudioType.PlayerSpread);
		}

		private void Shoot(Vector3 direction){
			const float angleIncrement = 10f;
			var startingAngle = -(shootScaleCount - 1) * angleIncrement / 2f;

			for(var i = 0; i < shootScaleCount; i++){
				var bulletClone = Instantiate(scaleBullet, transform.position + direction * fireRange,
					Quaternion.identity);

				var currentAngle = startingAngle + i * angleIncrement;
				var rotation = Quaternion.AngleAxis(currentAngle, Vector3.forward);

				bulletClone.transform.up = rotation * direction;
				bulletClone.GetComponent<Rigidbody2D>().AddForce(bulletClone.transform.up * 10, ForceMode2D.Impulse);
			}

			GameStateManager.StateManager.audioManger.PlaySfx(AudioManager.AudioType.PlayerShooting);
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