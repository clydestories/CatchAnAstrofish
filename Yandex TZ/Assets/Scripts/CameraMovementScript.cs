using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    [SerializeField] private int _speed;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
}
