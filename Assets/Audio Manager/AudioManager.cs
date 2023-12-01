using UnityEngine;

public class AudioManager : MonoBehaviour{
	[Header("Audio Source")] [SerializeField]
	private AudioSource music;

	[SerializeField] private AudioSource sound;

	[Header("Audio Clip")]
	public AudioClip background;

	public AudioClip playerShooting;
	public AudioClip playerHurt;
	public AudioClip playerDash;
	public AudioClip enemyDie;
	public AudioClip collectItems;

	private void Start(){
		music.clip = background;
		music.Play();
	}

	public void PlaySfx(AudioClip clip){
		sound.PlayOneShot(clip);
	}
}