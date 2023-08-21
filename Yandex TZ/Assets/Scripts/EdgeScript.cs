using UnityEngine;

public class EdgeScript : MonoBehaviour
{
    private GameLogicScript _gameLogicScript;
    private void Awake()
    {
        _gameLogicScript = FindFirstObjectByType<GameLogicScript>();
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
