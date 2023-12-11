using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private float _moveSpeed;
    private float _rotationSpeed;

    private void Start()
    {
        _moveSpeed = 3f;
        _rotationSpeed = 35f;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float direction = Input.GetAxis(Vertical);

        transform.Translate(_moveSpeed * Time.deltaTime * direction * Vector3.forward);
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis(Horizontal);

        transform.Rotate(_rotationSpeed * Time.deltaTime * rotation * Vector3.up);
    }
}
