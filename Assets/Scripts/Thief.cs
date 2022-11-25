using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float direction = Input.GetAxis("Vertical");

        transform.position += new Vector3(0, direction * _speed * Time.deltaTime, 0);
    }
}
