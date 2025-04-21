using UnityEngine;

namespace Systems.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
     
        private Rigidbody _rb;
        private Vector2 _direction = Vector2.zero;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            if (speed <= 0)
            {
                speed = 5f;
                Debug.LogWarning("Player speed is not set. Defaulting to 5.", this);
            }
        }

        private void Update()
        {
            // Get Input from all axes
            _direction.x = Input.GetAxis("Horizontal");
            _direction.y = Input.GetAxis("Vertical");
            _direction.Normalize();
            
            Move();
        }
        

        private void Move()
        {
            // Move player with a rigidbody
            float fixedSpeed = speed * Time.deltaTime;
            
            // Move player in the direction of input
            Vector3 moveDirection = new Vector3(_direction.x, 0, _direction.y);
            _rb.MovePosition(_rb.position + moveDirection * fixedSpeed);
        
        }
    }
}
