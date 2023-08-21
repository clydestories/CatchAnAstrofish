using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameLogicScript : MonoBehaviour
{
    [SerializeField] private GameObject _defeatScreen;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _playerFirstPrefab;

    private PlayerScript _playerScript;
    private int _gameSceneIndex = 1;
    private int _menuSceneIndex = 0;


    private static GameObject _playerPrefab;

    private void Awake()
    {
        if (_playerPrefab == null)
        {
            _playerPrefab = _playerFirstPrefab;
        }
        
        Instantiate(_playerPrefab);
    }

    public void Start()
    {
        _playerScript = FindAnyObjectByType<PlayerScript>();
    }

    public void Restart()
    {
        SceneManager.LoadScene(_gameSceneIndex);
        Time.timeScale = 1.0f;
    }

    public void Defeat()
    {
        Time.timeScale = 0;
        _scoreText.text = _playerScript.GetCoinOnThisAttempt().ToString();
        GetComponent<AudioSource>().Stop();
        _defeatScreen.SetActive(true);

    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(_menuSceneIndex);
    }

    public void SetPrefabVariation(GameObject _prefab)
    {
        _playerPrefab = _prefab;
    }
}
