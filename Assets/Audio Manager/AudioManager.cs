using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour{
	private AudioSource sound;

	public AudioClip playerShooting;
	public AudioClip playerHurt;
	public AudioClip playerDash;
	public AudioClip playerSpread;
	public AudioClip enemyDie;
	public AudioClip collectItems;
	public AudioClip defeated;
	public AudioClip win;
	public AudioClip notEnoughMoney;
	public AudioClip buy;

	private void Start(){
		sound = GetComponent<AudioSource>();
	}

	public void PlaySfx(AudioType type){
		switch(type){
			case AudioType.PlayerShooting:
				sound.PlayOneShot(playerShooting);
				break;
			case AudioType.PlayerHurt:
				sound.PlayOneShot(playerHurt);
				break;
			case AudioType.PlayerDash:
				sound.PlayOneShot(playerDash);
				break;
			case AudioType.PlayerSpread:
				sound.PlayOneShot(playerSpread);
				break;
			case AudioType.EnemyDie:
				sound.PlayOneShot(enemyDie);
				break;
			case AudioType.CollectItems:
				sound.PlayOneShot(collectItems);
				break;
			case AudioType.Defeated:
				sound.PlayOneShot(defeated);
				break;
			case AudioType.Win:
				sound.PlayOneShot(win);
				break;
			case AudioType.NotEnoughMoney:
				sound.PlayOneShot(notEnoughMoney);
				break;
			case AudioType.Buy:
				sound.PlayOneShot(buy);
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(type), type, null);
		}
	}

	public enum AudioType{
		PlayerShooting,
		PlayerHurt,
		PlayerDash,
		PlayerSpread,

		EnemyDie,
		CollectItems,

		Defeated,
		Win,

		NotEnoughMoney,
		Buy,
	}
}