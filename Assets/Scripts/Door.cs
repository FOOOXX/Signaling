using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private UnityEvent _robberEntered = new();
    [SerializeField] private UnityEvent _robberExit = new();

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovement>())
            _robberEntered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
            _robberExit?.Invoke();
    }
}
