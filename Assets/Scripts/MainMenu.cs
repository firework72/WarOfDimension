using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");    // "GameScene"은 실제 게임 씬 이름        
    }

    public void OpenOptions()
    {
        Debug.Log("옵션 창 열기");  // 옵션 메뉴 UI 구현 예정
    }

    public void QuitGame()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }
}