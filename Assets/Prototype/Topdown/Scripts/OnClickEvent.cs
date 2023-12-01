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
	}
}