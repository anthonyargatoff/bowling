using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField] private InputManager inputManager;
  [SerializeField] private float speed;
  private Rigidbody playerRigidbody;
  void Start()
  {
    inputManager.OnMove.AddListener(MovePlayer);
    playerRigidbody = GetComponent<Rigidbody>();
  }

  private void MovePlayer(Vector2 direction)
  {
    Vector3 moveDirection = new(direction.x, 0f, direction.y);
    playerRigidbody.AddForce(speed * moveDirection);
  }

  // Update is called once per frame
  void Update()
  {

  }
}
