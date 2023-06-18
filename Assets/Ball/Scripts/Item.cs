using System;
using UnityEngine;

namespace Ball.Scripts
{
   public class Item : MonoBehaviour
   {
      public event Action<Item> OnDisabled=delegate(Item item) {  };
      void OnDisable() => OnDisabled(this);
   }
}
