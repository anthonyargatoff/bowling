using UnityEngine;

public class BallController : MonoBehaviour
{
  [SerializeField] private float force = 1f;
  [SerializeField] private InputManager inputManager;
  private Rigidbody ballRigidbody;
  private bool isBallLaunched = false;

  void Start()
  {
    ballRigidbody = GetComponent<Rigidbody>();
    inputManager.OnSpacePressed.AddListener(LaunchBall);
  }

  void Update()
  {

  }

  private void LaunchBall()
  {
    if (isBallLaunched) return;
    isBallLaunched = true;
    ballRigidbody.AddForce(transform.forward * force, ForceMode.Impulse);
  }
}
