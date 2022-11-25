using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    [SerializeField] private float _maxVolume = 1.0f;
    [SerializeField] private float _volumeToggleStep = 0.1f;

    private AudioSource _audioSource;
    private bool _isIncreaseNeeded;
    private WaitForSeconds _waitTime = new WaitForSeconds(1);

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Thief>())
        {
            _isIncreaseNeeded = true;
            StartCoroutine(IncreaseVolume());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Thief>())
        {
            _isIncreaseNeeded = false;
            StartCoroutine(DecreaseVolume());
        }
    }

    private IEnumerator IncreaseVolume()
    {
        while (_audioSource.volume < _maxVolume && _isIncreaseNeeded)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _volumeToggleStep);
            yield return _waitTime;
        }
    }

    private IEnumerator DecreaseVolume()
    {
        while (_audioSource.volume > 0 && _isIncreaseNeeded == false)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0, _volumeToggleStep);
            yield return _waitTime;
        }
    }
}
