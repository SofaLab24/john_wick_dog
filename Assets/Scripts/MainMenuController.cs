using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    public List<Texture2D> backgrounds;
    public float switchTimer = 5f;
    private float currentTimer;

    private int currentBackground;
    private UIDocument mainMenuUI;
    private VisualElement backgroundElement;
    private Button startButton;
    private Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
        mainMenuUI = GetComponent<UIDocument>();
        backgroundElement = mainMenuUI.rootVisualElement.Q<VisualElement>("Container");
        startButton = mainMenuUI.rootVisualElement.Q<Button>("StartButton");
        startButton.clicked += StartGame;
        exitButton = mainMenuUI.rootVisualElement.Q<Button>("ExitButton");
        exitButton.clicked += ExitGame;
        backgroundElement.style.backgroundImage = backgrounds[0];
        currentBackground = 1;
        currentTimer = switchTimer;
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        currentTimer -= Time.deltaTime;
        if (currentTimer <= 0)
        {
            UpdateBackground();
            currentTimer = switchTimer;
        }
    }

    private void UpdateBackground()
    {
        if (currentBackground == backgrounds.Count)
        {
            currentBackground = 1;
            backgroundElement.style.backgroundImage = backgrounds[0];
        }
        else
        {
            backgroundElement.style.backgroundImage = backgrounds[currentBackground];
            currentBackground++;
        }
    }
}
