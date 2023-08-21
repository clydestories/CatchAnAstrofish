using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().AddCoinOnThisAttempt();
            AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, Vector3.zero);
            Destroy(gameObject);
        }
    }
}
