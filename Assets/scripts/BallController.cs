using UnityEngine;

public class BallController : MonoBehaviour
{
  [SerializeField] private float force = 1f;
  [SerializeField] private Transform ballAnchor;
  [SerializeField] private InputManager inputManager;
  private Rigidbody ballRigidbody;
  private bool isBallLaunched = false;

  void Start()
  {
    ballRigidbody = GetComponent<Rigidbody>();
    inputManager.OnSpacePressed.AddListener(LaunchBall);
    transform.parent = ballAnchor;
    transform.localPosition = Vector3.zero;
    ballRigidbody.isKinematic = true;
  }

  void Update()
  {

  }

  private void LaunchBall()
  {
    if (isBallLaunched) return;
    isBallLaunched = true;
    transform.parent = null;
    ballRigidbody.isKinematic = false;
    ballRigidbody.AddForce(transform.forward * force, ForceMode.Impulse);
  }
}
