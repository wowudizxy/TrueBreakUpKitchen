using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    private Coroutine stateTimerCoroutine;
    public static GameManager Instance { get; private set; }
    private GameInput gameInput;
    [SerializeField] private float waitingToStartDuration = 3f;
    [SerializeField] private float countDownToStartDuration = 3f;
    [SerializeField] private float gamePlayingDuration = 3f;
    private float gamePlayingtimer = 0;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnPaused;
    public event EventHandler OnWaitingToStarted;
    public event EventHandler OnCountDownStarted;
    public event EventHandler OnGamePlayingStarted;
    public event EventHandler OnGameOverStarted;
    private bool isPasue = false;
    private bool isActive = true;
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
        //DontDestroyOnLoad(gameObject);
        state = State.WaitingToStart;

    }


    private void Start()
    {
        gameInput = GameObject.Find("GameInput").GetComponent<GameInput>();
        stateTimerCoroutine= StartCoroutine(StateTimer(0, () => ConvertState(State.WaitingToStart)));
        gameInput.PauseHandler += GameInput_PauseHandler;
        gameInput.InteractHandler += GameInput_InteractHandler;
    }

    private void GameInput_InteractHandler(object sender, EventArgs e)
    {
        if(state == State.WaitingToStart)
        {
            if (stateTimerCoroutine != null)
            {
                StopCoroutine(stateTimerCoroutine);
            }
            ConvertState(State.CountDownToStart);
        }
    }

    private void Update()
    {
        if (IsGamePlaying())
        {
            gamePlayingtimer += Time.deltaTime;
        }
    }
    private void OnDestroy()
    {
        gameInput.PauseHandler -= GameInput_PauseHandler;
    }

    private void GameInput_PauseHandler(object sender, EventArgs e)
    {
        print("GameInput_PauseHandler");
        print(isActive);
        if (isActive == true)
        {
            print("SwitchPause");
            SwitchPause();
        }
    }

    private IEnumerator StateTimer(float duration, Action onComplete)
    {
        yield return new WaitForSeconds(duration);
        onComplete?.Invoke();
    }

    private void ConvertState(State newState)
    {
        StopAllCoroutines();
        state = newState;

        switch (state)
        {
            case State.WaitingToStart:
                OnWaitingToStart();
                OnWaitingToStarted?.Invoke(this, EventArgs.Empty);
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
    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }
    public void SwitchPause()
    {

        isPasue = !isPasue;
        if (isPasue)
        {
            Time.timeScale = 0;
            OnGamePaused?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Time.timeScale = 1;
            OnGameUnPaused?.Invoke(this, EventArgs.Empty);
        }
    }
    public void SetIsPauseActive(bool isOpen)
    {
        isActive = isOpen;
    }
    public float GetGamePlayingtimer()
    {
        return gamePlayingDuration- gamePlayingtimer;
    }
    public float GetGamePlayingTimerNormalzed()
    {
        return gamePlayingtimer / gamePlayingDuration;
    }
    public bool IsWaiting()
    {
        return state == State.WaitingToStart;
    }
}
