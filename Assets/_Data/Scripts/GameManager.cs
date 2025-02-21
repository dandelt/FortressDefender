using System;
using UnityEngine;

public class GameManager : DanSingleton<GameManager>
{
    [SerializeField] protected Transform mainMenu;
    [SerializeField] protected Transform gameOver;
    [SerializeField] protected Transform gamePause;

    protected override void Start()
    {
        this.MainMenu();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMainMenu();
        this.LoadGameOver();
        this.LoadGamePause();
    }

    protected virtual void LoadMainMenu()
    {
        if (this.mainMenu != null) return;
        this.mainMenu = FindAnyObjectByType<MainMenu>().transform;
        Debug.Log(transform.name + ": LoadMainMenu", gameObject);
    }

    protected virtual void LoadGameOver()
    {
        if (this.gameOver != null) return;
        this.gameOver = FindAnyObjectByType<GameOver>().transform;
        Debug.Log(transform.name + ": LoadGameOver", gameObject);
    }

    protected virtual void LoadGamePause()
    {
        if (this.gamePause != null) return;
        this.gamePause = FindAnyObjectByType<GamePause>().transform;
        Debug.Log(transform.name + ": LoadGamePause", gameObject);
    }

    public virtual void MainMenu()
    {
        this.mainMenu.gameObject.SetActive(true);
        this.gameOver.gameObject.SetActive(false);
        this.gamePause.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    public virtual void GameOver()
    {
        this.gameOver.gameObject.SetActive(true);
        this.gamePause.gameObject.SetActive(false);
        this.mainMenu.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    public virtual void GamePause()
    {
        this.gamePause.gameObject.SetActive(true);
        this.gameOver.gameObject.SetActive(false);
        this.mainMenu.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    public virtual void StartGame()
    {
        this.mainMenu.gameObject.SetActive(false);
        this.gameOver.gameObject.SetActive(false);
        this.gamePause.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public virtual void ResumeGame()
    {
        this.mainMenu.gameObject.SetActive(false);
        this.gameOver.gameObject.SetActive(false);
        this.gamePause.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}