using UnityEngine;
using TMPro;
using System.Collections;

public class ShopScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _fishesAmountText;
    [SerializeField] private GameLogicScript _gameLogicScript;
    [SerializeField] private GameObject _alertScreen;
    [SerializeField] private AudioClip _failedSound;

    private bool _canBuy = false;
    private PlayerScript _playerScript;

    private void Awake()
    {
        _playerScript = FindAnyObjectByType<PlayerScript>();
    }

    public void Start()
    {
        _fishesAmountText.text = _playerScript.GetCoinsAmount().ToString() + " Fishes";
    }

    public void BuyUpgrade(int amount)
    {
        if (amount <= _playerScript.GetCoinsAmount())
        {
            GameObject button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

            _playerScript.SubstractCoinsFromPlayer(amount);
            button.GetComponent<AudioSource>().Play();
            _canBuy = true;
        }
        else
        {
            StartCoroutine(SendAlert(3f, "You can't afford to buy that"));
        }
    }

    public void SetPrefab(GameObject prefab)
    {
        if (_canBuy)
        {
            _gameLogicScript.SetPrefabVariation(prefab);
            _canBuy = false;
        }
    }

    private IEnumerator SendAlert(float duration, string message)// dif message?
    {
        _alertScreen.GetComponentInChildren<TextMeshProUGUI>().text = message;
        _alertScreen.SetActive(true);
        AudioSource.PlayClipAtPoint(_failedSound, Vector3.zero);
        yield return new WaitForSecondsRealtime(duration);
        _alertScreen.SetActive(false);
    }
}
