using UnityEngine;

public class ForcefieldScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            int playerGravityForce = 5;
            Vector3 playerDirection = (transform.position - collision.transform.position) * playerGravityForce;
            collision.attachedRigidbody.AddForce(playerDirection);
        }
    }
}
