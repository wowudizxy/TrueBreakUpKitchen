using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private float waitingToStartDuration = 3f;
    [SerializeField] private float countDownToStartDuration = 3f;
    [SerializeField] private float gamePlayingDuration = 3f;

    public event EventHandler OnCountDownStarted;
    public event EventHandler OnGamePlayingStarted;
    public event EventHandler OnGameOverStarted;

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
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        state = State.WaitingToStart;
    }

    private void Start()
    {
        StartCoroutine(StateTimer(0, () => ConvertState(State.WaitingToStart)));
    }

    private IEnumerator StateTimer(float duration, Action onComplete)
    {
        yield return new WaitForSeconds(duration);
        onComplete?.Invoke();
    }

    private void ConvertState(State newState)
    {
        state = newState;

        switch (state)
        {
            case State.WaitingToStart:
                OnWaitingToStart();
                StartCoroutine(StateTimer(waitingToStartDuration, () => ConvertState(State.CountDownToStart)));
                break;

            case State.CountDownToStart:
                OnCountDownToStart();
                OnCountDownStarted?.Invoke(this, EventArgs.Empty);
                StartCoroutine(StateTimer(countDownToStartDuration, () => ConvertState(State.GamePlaying)));
                break;

            case State.GamePlaying:
                OnGamePlaying();
                OnGamePlayingStarted?.Invoke(this, EventArgs.Empty);
                StartCoroutine(StateTimer(gamePlayingDuration, () => ConvertState(State.GameOver)));
                break;

            case State.GameOver:
                OnGameOver();
                OnGameOverStarted?.Invoke(this, EventArgs.Empty);
                break;
        }
    }

    private void OnWaitingToStart()
    {
        HandlePlayerState(false);
    }

    private void OnCountDownToStart()
    {
        HandlePlayerState(false);
        // Additional logic for countdown (e.g., UI updates) can be added here.
    }

    private void OnGamePlaying()
    {
        HandlePlayerState(true);
        // Additional logic for game playing (e.g., UI updates) can be added here.
    }

    private void OnGameOver()
    {
        HandlePlayerState(false);
        // Additional logic for game over (e.g., displaying final score) can be added here.
    }

    private void HandlePlayerState(bool isEnabled)
    {
        if (Player.Instance != null)
        {
            Player.Instance.enabled = isEnabled;
            Player.Instance.GetComponentInChildren<Animator>().enabled = isEnabled;
        }
    }
}
