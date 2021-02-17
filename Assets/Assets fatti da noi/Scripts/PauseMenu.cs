using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    [HideInInspector]
    public bool isPaused;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                pausePanel.SetActive(true);
            }
            else
            {
                pausePanel.SetActive(false);
            }
        }

    }

	public void resume()
	{
		pausePanel.SetActive(false);
		isPaused = false;
	}

	public void exit()
	{
		Debug.Log("DA IMPLEMENTARE L'EXIT");
		Application.Quit();
	}
}
