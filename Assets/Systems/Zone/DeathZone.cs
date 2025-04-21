using Systems.Player;
using UnityEngine;

namespace Systems.Zone
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            // Check if the object that collided with the death zone has a PlayerData component
            PlayerData playerData = other.gameObject.GetComponent<PlayerData>();
            if (playerData)
            {
                // Reset the player's position to the initial position
                other.transform.position = playerData.InitialPosition;
                Debug.Log("Player has died and respawned at the initial position.");
            }
            else
            {
                Debug.LogWarning("Collision with non-player object detected. No action taken.");
            }
        }
    }
}