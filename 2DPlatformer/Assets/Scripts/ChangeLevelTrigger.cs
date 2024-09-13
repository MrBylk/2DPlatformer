using UnityEngine;

public class ChangeLevelTrigger : MonoBehaviour
{
    [SerializeField] private Vector3 _previousLevelPosition;
    [SerializeField] private Vector3 _nextLevelPosition;

    private Transform _camera;

    private void Awake()
    {
        _camera = Camera.main.transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out _))
        {
            Vector2 directionToPlayer = (collision.transform.position - transform.position).normalized;

            if (directionToPlayer.x > 0)
            {
                _camera.position = _nextLevelPosition;
            }
            else
            {
                _camera.position = _previousLevelPosition;
            }
        }
    }
}