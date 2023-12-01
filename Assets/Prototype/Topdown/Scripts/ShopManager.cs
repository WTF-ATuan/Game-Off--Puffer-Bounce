using System;
using UnityEngine;

namespace Prototype.Topdown{
	public class ShopManager : MonoBehaviour{
		private PlayerData _playerData;


		private void Start(){
			_playerData = GameStateManager.StateManager.PlayerData;
		}
	}
}