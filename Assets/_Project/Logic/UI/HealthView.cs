using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        
        public void UpdateValue(float value) => 
            _slider.value = value;
    }
}
