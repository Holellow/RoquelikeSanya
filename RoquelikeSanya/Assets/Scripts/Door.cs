using UnityEngine;

public class Door : MonoBehaviour, IActive
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Active()
    {
        GetComponent<EdgeCollider2D>().enabled = false;
        _animator.SetBool("isOpen",true);
    }
}
