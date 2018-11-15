using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject instructions;
    [SerializeField] GameObject instructionsNext;
    [SerializeField] GameObject playerLose;
    [SerializeField] GameObject playerWin;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject playerStartPosition;


    void Start()
    {
        DelayMainMenuDisplay();
    }

    void OnEnable()
    {
        EventManager.onStartGame += ShowGameUI;
        EventManager.onInstructionsGame += InstructionsDisplay;
        EventManager.onBackGame += BackGame;
        EventManager.onNextGame += NextGame;
        EventManager.onPreviousGame += PreviousGame;
        EventManager.onPlayerDeath += PlayerLose;
        EventManager.onPlayerWin += PlayerWin;
    }


    void OnDisable()
    {
        EventManager.onStartGame -= ShowGameUI;
        EventManager.onPlayerDeath -= PlayerLose;
        EventManager.onBackGame -= BackGame;
        EventManager.onNextGame -= NextGame;
        EventManager.onPreviousGame -= PreviousGame;
        EventManager.onInstructionsGame -= InstructionsDisplay;
        EventManager.onPlayerWin -= PlayerWin;
    }


    void ShowMainMenu()
    {
        Invoke("DelayMainMenuDisplay", Asteroid.desctructionDelay * 3);
    }

    void BackGame()
    {
        mainMenu.SetActive(true);
        gameUI.SetActive(false);
        instructions.SetActive(false);
        instructionsNext.SetActive(false);
        playerLose.SetActive(false);
        playerWin.SetActive(false);
    }

    void NextGame()
    {
        mainMenu.SetActive(false);
        gameUI.SetActive(false);
        instructions.SetActive(false);
        instructionsNext.SetActive(true);
        playerLose.SetActive(false);
        playerWin.SetActive(false);
    }

    void PreviousGame()
    {
        mainMenu.SetActive(false);
        gameUI.SetActive(false);
        instructions.SetActive(true);
        instructionsNext.SetActive(false);
        playerLose.SetActive(false);
        playerWin.SetActive(false);
    }


    void DelayMainMenuDisplay()
    {
        mainMenu.SetActive(true);
        gameUI.SetActive(false);
        instructions.SetActive(false);
        instructionsNext.SetActive(false);
        playerLose.SetActive(false);
        playerWin.SetActive(false);
    }

    void InstructionsDisplay()
    {
        instructions.SetActive(true);
        mainMenu.SetActive(false);
        gameUI.SetActive(false);
        instructionsNext.SetActive(false);
        playerLose.SetActive(false);
        playerWin.SetActive(false);
    }

    void PlayerLose()
    {
        playerLose.SetActive(true);
        instructions.SetActive(false);
        mainMenu.SetActive(false);
        gameUI.SetActive(false);
        instructionsNext.SetActive(false);
        playerWin.SetActive(false);
    }

    void PlayerWin()
    {
        playerWin.SetActive(true);
        playerLose.SetActive(false);
        instructions.SetActive(false);
        mainMenu.SetActive(false);
        gameUI.SetActive(false);
        instructionsNext.SetActive(false);
    }

    void ShowGameUI()
    {
        mainMenu.SetActive(false);
        gameUI.SetActive(true);
        instructions.SetActive(false);
        instructionsNext.SetActive(false);
        playerLose.SetActive(false);
        playerWin.SetActive(false);

        Instantiate(playerPrefab, playerStartPosition.transform.position, playerStartPosition.transform.rotation);
    }
}
