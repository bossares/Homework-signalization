using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    [SerializeField] private float _volumeToggleStep = 0.1f;
    [SerializeField] private WaitForSeconds _waitTime = new WaitForSeconds(1);

    private AudioSource _audioSource;
    private bool _isIncreaseNeeded;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(ToggleVolume());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isIncreaseNeeded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isIncreaseNeeded = false;
    }

    private IEnumerator ToggleVolume()
    {
        while (true)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, Convert.ToSingle(_isIncreaseNeeded), _volumeToggleStep);
            yield return _waitTime;
        }
    }
}
