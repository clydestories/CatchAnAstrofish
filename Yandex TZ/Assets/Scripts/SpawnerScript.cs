using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private int _amount;
    [SerializeField] private GameObject _Prefab;

    void Start()
    {
        Spawn(_amount);
        gameObject.GetComponent<SpawnerScript>().enabled = false;
    }
     
    private void Spawn(int amount)
    {
        float spawnerWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        float spawnerHeight = GetComponent<SpriteRenderer>().bounds.size.y;
        int initialCoinValue = 1;
        int initialObstacleValue = 2;
        int levelOfObjectAmountIncrease = 5;
        int obstacleRate = 2;

        if (_Prefab.tag == "Coin")
        {
            amount = initialCoinValue + (FindObjectOfType<PlayerScript>().GetLevel() / levelOfObjectAmountIncrease);
        }
        else
        {
            amount = initialObstacleValue + (FindObjectOfType<PlayerScript>().GetLevel() / levelOfObjectAmountIncrease * obstacleRate);
        }

        for (int i = 0; i < amount; i++)
        {
            float randomY = Random.Range(-spawnerHeight / 2, spawnerHeight / 2);
            float randomX = Random.Range(-spawnerWidth / 2, spawnerWidth / 2);


            GameObject wrapper = new GameObject("ObjectWrapper");
            wrapper.transform.position = gameObject.transform.position + new Vector3(randomX, randomY, 0);
            wrapper.transform.parent = gameObject.transform;
            GameObject obstacle = Instantiate(_Prefab, wrapper.transform);
        }
    }
}