using System.Collections;
using UnityEngine;

namespace Systems.Player
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private float jumpCheckDistance;
        [SerializeField] private float jumpForce;
        [SerializeField] private float jumpCooldown;
        
        private Rigidbody _rb;
        private bool _canJump;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _canJump = true;
            
            if (jumpCheckDistance <= 0)
            {
                jumpCheckDistance = 1f;
                Debug.LogWarning("Jump check distance is not set. Defaulting to 1.", this);
            }

            if (jumpForce <= 0)
            {
                jumpForce = 5f;
                Debug.LogWarning("Jump force is not set. Defaulting to 5.", this);
            }
            
            if (jumpCooldown <= 0)
            {
                jumpCooldown = 1f;
                Debug.LogWarning("Jump cooldown is not set. Defaulting to 1.", this);
            }
        }

        private void Update()
        {
            // Check if the player is grounded
            if ( CanExecuteJump() && Input.GetButtonDown("Jump"))
            {
                StartCoroutine(Jump());
            }
        }
        
        private IEnumerator Jump()
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // TODO: Change _canJump to a count down
            _canJump = false;
            yield return new WaitForSeconds(jumpCooldown);
            _canJump = true;

        }

        private bool CanExecuteJump()
        {
            bool isGrounded = Physics.Raycast(transform.position, Vector3.down, jumpCheckDistance);
            return isGrounded && _canJump;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * jumpCheckDistance);
        }
    }
}