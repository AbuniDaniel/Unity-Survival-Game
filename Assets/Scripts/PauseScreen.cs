using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    
    public void ResumeButton( )
    {   
        Time.timeScale = 1;
    }

    public void RestartButton( )
    {   
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenuButton( )
    {   
        SceneManager.LoadScene("Menu");
    }

    public void PauseButton( )
    {   
        Time.timeScale = 0;
    }

}
