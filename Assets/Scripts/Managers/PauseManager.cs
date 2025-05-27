using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseUI;  // 일시정지 UI 패널
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   // ESC 입력
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (pauseUI != null)
        {
            pauseUI.SetActive(true);    // 일시정지 UI 표시
        }
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (pauseUI != null)
        {
            pauseUI.SetActive(false);   // 일시정지 UI 숨김
        }
    }

    public void Exit()
    {
        Time.timeScale = 1f;    // 씬 이동 전 반드시 시간 복구
        SceneManager.LoadScene("Mainmenu");
    }
}
