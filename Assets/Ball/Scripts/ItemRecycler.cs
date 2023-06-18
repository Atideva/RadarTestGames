using System;
using UnityEngine;

namespace Ball.Scripts
{
    public class ItemRecycler : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            other.gameObject.SetActive(false);
        }
    }
}