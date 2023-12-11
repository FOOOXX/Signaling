using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Signaling : MonoBehaviour
{
    private AudioSource _audioSource;
    private Coroutine _current;

    private float _minVolume;
    private float _maxVolume;
    private float _speed;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _minVolume = 0f;
        _maxVolume = 1f;
        _speed = 0.05f;

        _audioSource.Play();
    }

    public void TurnOn()
    {
        if(_current != null)
        {
            StopCoroutine( _current );
        }

        _current = StartCoroutine(ChangeVolumeSound(_maxVolume));
    }

    public void TurnOff()
    {
        StopCoroutine(_current);

        _current = StartCoroutine(ChangeVolumeSound(_minVolume));
    }

    private IEnumerator ChangeVolumeSound(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _speed * Time.deltaTime);

            yield return null;
        }
    }
}