using UnityEngine;

public class LevelGeneratorScript : MonoBehaviour
{
    [SerializeField] private GameObject _levelPrefab;

    private const float _levelWidth = 34;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(_levelPrefab, new Vector3(transform.position.x + _levelWidth, 0, 0), Quaternion.identity);
            collision.GetComponent<PlayerScript>().AddLevel();
        }
    }
}

