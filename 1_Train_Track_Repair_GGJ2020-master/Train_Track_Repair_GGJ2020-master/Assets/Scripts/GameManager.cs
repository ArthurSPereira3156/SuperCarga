using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

  void Start()
    {
        // muda para retrato para escolher as fases
        //Screen.orientation = ScreenOrientation.LandscapeLeft;
        AudioController.getInstance().trocarMusica( AudioController.getInstance().musicaTitulo);
    }
  public void playGame(){
    AudioController.getInstance().tocarFx(AudioController.getInstance().fxClick);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

  public void credits(){
    SceneManager.LoadScene("Menu");
  }

  public void quitGame(){
    Application.Quit();
  }
  public void levelSelect(){
    AudioController.getInstance().tocarFx(AudioController.getInstance().fxClick);
		SceneManager.LoadScene("FaseSelect");
  }

  public void playAgain(){
    AudioController.getInstance().tocarFx(AudioController.getInstance().fxClick);
		SceneManager.LoadScene("LevelDinamico");
	}
}
