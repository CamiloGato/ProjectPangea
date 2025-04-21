using UnityEngine;

namespace Systems.Player
{
    public class PlayerData : MonoBehaviour
    {
        public Vector3 InitialPosition
        {
            get;
            private set;
        }

        private void Start()
        {
            InitialPosition = transform.position;
        }
    }
}