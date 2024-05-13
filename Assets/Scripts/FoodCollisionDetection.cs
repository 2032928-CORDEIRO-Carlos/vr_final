using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            FoodItem foodItem = other.GetComponent<FoodItem>();
            if (foodItem != null)
            {
                foodItem.EatFood();
            }
        }
    }
}

