using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsAmountText;

    private PlayerScript _playerScript;

    private void Start()
    {
        _playerScript = FindAnyObjectByType<PlayerScript>();
    }

    void Update()
    {
        _coinsAmountText.text = _playerScript.GetCoinOnThisAttempt().ToString();
    }

    public void OpenWindow(GameObject windowToOpen)
    {
        CloseWindow();
        windowToOpen.SetActive(true);
    }

    public void CloseWindow()
    {
        GameObject window = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        window.SetActive(false);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
