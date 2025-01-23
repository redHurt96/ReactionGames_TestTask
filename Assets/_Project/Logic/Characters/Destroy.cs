using UnityEngine;

namespace _Project.Characters
{
    public class Destroy : MonoBehaviour
    {
        public void Execute() => 
            Destroy(gameObject);

        public void ExecuteDelayed(float autoDestroyTime) => 
            Destroy(gameObject, autoDestroyTime);
    }
}