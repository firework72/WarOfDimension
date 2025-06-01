using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] tutorialPanels;
    public Button nextButton;
    public Button prevButton;
    public Button backButton;

    private int currentStep = 0;

    void Start()
    {
        ShowStep(0);

        nextButton.onClick.AddListener(NextStep);
        prevButton.onClick.AddListener(PrevStep);
        backButton.onClick.AddListener(GoToMainMenu);
    }

    void ShowStep(int step)
    {
        // 모든 패널을 비활성화
        for (int i = 0; i < tutorialPanels.Length; i++)
        {
            tutorialPanels[i].SetActive(i == step);
        }

        // 버튼 활성/비활성 관리
        prevButton.interactable = (step > 0);
        nextButton.interactable = (step < tutorialPanels.Length - 1);
    }

    public void NextStep()
    {
        if (currentStep < tutorialPanels.Length - 1)
        {
            currentStep++;
            ShowStep(currentStep);
        }
    }

    public void PrevStep()
    {
        if (currentStep > 0)
        {
            currentStep--;
            ShowStep(currentStep);
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}