using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float _pushForceAmount = 6f;
    [SerializeField] private int _speed;
    [SerializeField] private int _level;
    [SerializeField] private int _coinsCollectedOnThisAttempt;

    private Rigidbody2D _playerRigidbody;
    private static int _coins = 999; // 999 Left for testing purposes

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void PushUp()
    {
        _playerRigidbody.AddForce(Vector3.up * _pushForceAmount, ForceMode2D.Force);
    }

    private void FixedUpdate()
    {
        Move();

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
            PushUp();
    }

    private void Move()
    {
        _playerRigidbody.transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    public void AddCoinOnThisAttempt()
    {
        _coinsCollectedOnThisAttempt++;
        _coins++;
    }

    public int GetCoinOnThisAttempt()
    {
        return _coinsCollectedOnThisAttempt;
    }

    public int GetCoinsAmount()
    {
        return _coins;
    }

    public void AddLevel()
    {
        _level++;
    }

    public int GetLevel()
    {
        return _level;
    }

    public void SubstractCoinsFromPlayer(int amount)
    {
        _coins -= amount;
    }
}
