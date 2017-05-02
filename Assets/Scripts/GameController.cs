using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public AudioClip audio;

	void Start () {
        InputSystem.AddControl(PlayerIndex.Player1, new GamePad1(XboxCtrlrInput.XboxController.First));
        AudioController.Instance.Play(audio, AudioController.SoundType.SoundEffect2D);		
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
