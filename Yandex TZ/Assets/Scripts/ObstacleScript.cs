using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private GameLogicScript _gameLogicScript;
    private float _lowestSpeedLimit = 0.25f;
    private float _highestSpeedLimit = 1.0f;

    private void Awake()
    {
        _gameLogicScript = FindFirstObjectByType<GameLogicScript>();
    }

    void Start()
    {
        GetComponent<Animator>().SetFloat("Speed", Random.Range(_lowestSpeedLimit, _highestSpeedLimit));
        GetComponent<Animator>().SetBool("isGoingUp", Random.Range(0,2) == 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            _gameLogicScript.Defeat();
        }
    }
}
