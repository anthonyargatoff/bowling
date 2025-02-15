using UnityEngine;

public class BallController : MonoBehaviour
{
  [SerializeField] private float force = 1f;
  [SerializeField] private Transform ballAnchor;
  [SerializeField] private InputManager inputManager;
  [SerializeField] private Transform launchIndicator;
  [SerializeField] private AudioSource strikeSound;
  private Rigidbody ballRigidbody;
  private bool isBallLaunched;
  private bool hitPin;

  void Start()
  {
    ballRigidbody = GetComponent<Rigidbody>();
    inputManager.OnSpacePressed.AddListener(LaunchBall);
    ResetBall();
  }

  public void ResetBall()
  {
    isBallLaunched = false;
    ballRigidbody.isKinematic = true;
    launchIndicator.gameObject.SetActive(true);
    transform.parent = ballAnchor;
    transform.localPosition = Vector3.zero;
    hitPin = false;
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
    ballRigidbody.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
    launchIndicator.gameObject.SetActive(false);
  }

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "Pin" && !hitPin)
    {
      hitPin = true;
      strikeSound.Play();
    }
  }
}
