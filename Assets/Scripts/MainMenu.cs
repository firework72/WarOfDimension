using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource mainMenuBGM;
    private bool isMuted;

    void Start()
    {
        // 씬 시작 시 음소거 상태 불러오기
        isMuted = PlayerPrefs.GetInt("MuteState", 0) == 1;
        if (mainMenuBGM != null)
        {
            mainMenuBGM.mute = isMuted;
        }
    }

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

    public void ToggleBGM()
    {
        isMuted = !isMuted;
        if (mainMenuBGM != null)
        {
            mainMenuBGM.mute = isMuted;
        }
        PlayerPrefs.SetInt("MuteState", isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }
}