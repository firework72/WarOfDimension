using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneManager : MonoBehaviour
{
    public GameObject curScoreText;
    public GameObject returnToMainButton;
    void Start()
    {
        curScoreText.GetComponent<TextMeshProUGUI>().text = "Score : " + PlayerPrefs.GetInt("CurScore").ToString() + " wave";
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}