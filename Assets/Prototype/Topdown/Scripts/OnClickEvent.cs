using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Prototype.Topdown{
	public class OnClickEvent : MonoBehaviour, IPointerClickHandler{
		public UnityEvent onClick;

		public void OnPointerClick(PointerEventData eventData){
			onClick?.Invoke();
		}

		public void BackToGame(){
			GameStateManager.StateManager.ModifyState(GameState.GamePlay);
		}

		public void LoadStartCutScene(){
			GameStateManager.StateManager.ModifyState(GameState.CutScene, 0);
		}

		public void LoadCreditScene(){
			GameStateManager.StateManager.ModifyState(GameState.Credit);
		}

		public void LoadMainMenu(){
			GameStateManager.StateManager.ModifyState(GameState.MainMenu);
		}
	}
}