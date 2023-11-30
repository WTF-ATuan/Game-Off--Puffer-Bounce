using System;
using UnityEngine;

namespace Prototype.Topdown{
	public class TopdownBullet : MonoBehaviour{


		private void OnCollisionEnter2D(Collision2D col){
			if(col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("boss_0")) 
            {
				col.gameObject.GetComponent<TopdownEnemy>().Hit();
				Destroy(gameObject);
			}

			if(col.gameObject.CompareTag("Blocker")){
				Destroy(gameObject);
			}
		}
	}
}