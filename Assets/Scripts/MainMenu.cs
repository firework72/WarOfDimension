using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");    // "GameScene"은 실제 게임 씬 이름        
    }

    public void OpenTutorialScene()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void QuitGame()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }
}