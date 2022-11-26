using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    [SerializeField] private float _volumeToggleStep = 0.1f;

    private float _waitTime = 1;
    private AudioSource _audioSource;
    private bool _isIncreaseNeeded;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        InvokeRepeating(nameof(ToggleVolume), 0, _waitTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isIncreaseNeeded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isIncreaseNeeded = false;
    }

    private void ToggleVolume()
    {
        float targetValue = Convert.ToSingle(_isIncreaseNeeded);

        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetValue, _volumeToggleStep);
    }
}
