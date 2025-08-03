using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public enum GameState
    {
        INTRO,
        GAMEPLAY,
        OUTRO
    }
    private GameState currentState;
    [SerializeField] private GameObject introVideoPlayer;
    [SerializeField] private GameObject outroVideoPlayer;
    [SerializeField] private VideoPlayer outroPlayer;
    [SerializeField] private GameObject bg;

    private int numberOfZombiesKilled = 0;
    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        currentState = GameState.INTRO;
    }

    public void ZombieKilled()
    {
        numberOfZombiesKilled++;
    }

    void Update()
    {
        switch (currentState)
        {
            case GameState.INTRO:
                introVideoPlayer.SetActive(true);
                bg.SetActive(true);
                Time.timeScale = 0f;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentState = GameState.GAMEPLAY;
                }
                break;
            case GameState.GAMEPLAY:
                introVideoPlayer.SetActive(false);
                bg.SetActive(false);
                Time.timeScale = 1f;
                if (numberOfZombiesKilled >= 2) {
                    currentState = GameState.OUTRO;
                }
                break;
            case GameState.OUTRO:
                outroVideoPlayer.SetActive(true);
                bg.SetActive(true);
                outroPlayer.Play();
                break;
            default:
                break;
        }
    }
}
