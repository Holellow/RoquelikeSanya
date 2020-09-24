using Player;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _pos1, _pos2;
    [SerializeField] private Transform _startPos;
    
    [SerializeField] private float _platformSpeed;

    private Vector3 _nextPos;

    private bool IsActive { get; set; } = true;
    
    void Start()
    {
        _nextPos = _startPos.position;    
    }

    void FixedUpdate()
    {
        if (IsActive){
            if (transform.position == _pos1.position)
            {
                _nextPos = _pos2.position;
            }

            if (transform.position == _pos2.position)
            {
                _nextPos = _pos1.position;
            }

            transform.position = Vector3.MoveTowards(transform.position, _nextPos, _platformSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(_pos1.position, _pos2.position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerUnit>() != null)
        {
            collision.collider.transform.SetParent(transform);
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerUnit>() != null)
        {
            collision.collider.transform.SetParent(null);
        }
    }
}