using UnityEngine;

public class LevelDestroyerScript : MonoBehaviour
{
    [SerializeField] private int _speed;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
