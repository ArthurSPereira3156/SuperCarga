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

    }
  public void playGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

  public void credits(){
    SceneManager.LoadScene("Menu");
  }

  public void quitGame(){
    Application.Quit();
  }
  public void levelSelect(){
		SceneManager.LoadScene("FaseSelect");
  }

  public void playAgain(){
		SceneManager.LoadScene("LevelDinamico");
	}
}
