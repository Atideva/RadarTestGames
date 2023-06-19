using UnityEngine;
using UnityEngine.UI;

namespace Battle.Scripts
{
    public class UnitHitpointsUI : MonoBehaviour
    {
        public Slider slider;
        public Image fill;
        public Gradient gradient;

        public void SetValue(float value)
        {
            slider.value = value;
            fill.color = gradient.Evaluate(value);
        }
    }
}