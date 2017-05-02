using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public new AudioClip audio;

    public PlayerMovementBehaviour player;

	void Start () {
        InputSystem.AddControl(PlayerIndex.Player1, new KeyBoard());
        player.canMove = false;
        AudioController.Instance.Play(audio, AudioController.SoundType.Music);		
	}

    public void OnDie()
    {
        AudioController.Instance.StopAllSounds();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (InputSystem.AnyGamePadButtonDown(XboxCtrlrInput.XboxButton.Y))
            OnDie();
    }

}
