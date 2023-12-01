using UnityEngine;
using UnityEngine.Video;

namespace Prototype.Topdown{
	[RequireComponent(typeof(VideoPlayer))]
	public class VideoHandler : MonoBehaviour{
		private VideoPlayer _videoPlayer;
		public bool isGameStart;

		private void Start(){
			_videoPlayer = GetComponent<VideoPlayer>();
			_videoPlayer.loopPointReached += EndReached;
		}

		private void EndReached(VideoPlayer source){
			if(isGameStart){
				GameStateManager.StateManager.ModifyState(GameState.GamePlay);
			}
		}
	}
}