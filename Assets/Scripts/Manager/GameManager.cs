using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float waitingToStartTimer = 3;
    [SerializeField] private float countDownToStartTimer =3;
    [SerializeField] private float gamePlayingTimer = 3;
    public enum State
    {
        WaitingToStart,
        CountDownToStart,
        GamePlaying,
        GameOver
    }

    private State state;

    private void Awake()
    {
        state = State.WaitingToStart;
    }
    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer-= Time.deltaTime;
                OnWaitingToStart();
                if (waitingToStartTimer < 0)
                {
                    ConvertState(State.CountDownToStart);
                }
                break;
            case State.CountDownToStart:
                countDownToStartTimer -= Time.deltaTime;
                OnCountDownToStart();
                if (countDownToStartTimer < 0)
                {
                    ConvertState(State.GamePlaying);
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                OnGamePlaying();
                if (gamePlayingTimer<0)
                {
                    ConvertState(State.GameOver);
                }
                break;
            case State.GameOver:
                OnGameOver();
                break;
            default:
                break;
        }
    }
    public void ConvertState(State state)
    {
        this.state = state; 
    }
    public void OnWaitingToStart()
    {
        DisablePlayer();
    }
    public void OnCountDownToStart()
    {
        DisablePlayer();
    }
    public void OnGamePlaying()
    {
        EnablePlayer();
    }
    public void OnGameOver()
    {
        DisablePlayer();
    }
    public void DisablePlayer()
    {
        Player.Instance.enabled = false;
        Player.Instance.GetComponentInChildren<Animator>().enabled = false;
    }
    public void EnablePlayer()
    {
        Player.Instance.enabled = true;
        Player.Instance.GetComponentInChildren<Animator>().enabled = true;
    }
}
