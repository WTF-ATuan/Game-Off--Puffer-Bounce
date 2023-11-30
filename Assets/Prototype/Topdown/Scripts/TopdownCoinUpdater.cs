using TMPro;
using UnityEngine;

namespace Prototype.Topdown{
	public class TopdownCoinUpdater : MonoBehaviour{
		[SerializeField] private TMP_Text coinsText;
		[SerializeField] private TMP_Text healthCoinsText;

		private void LateUpdate(){
			var playerData = GameStateManager.StateManager.PlayerData;
			coinsText.text = playerData.Coins.ToString();
			healthCoinsText.text = playerData.HealthCoins.ToString();
		}
	}
}