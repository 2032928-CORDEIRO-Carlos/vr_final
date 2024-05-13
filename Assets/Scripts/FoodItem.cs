using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public GameObject Player;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            EatFood();
        }
    }

    public void EatFood()
    {
        audioSource.Play();
        Destroy(gameObject, audioSource.clip.length);
    }
}
