using UnityEngine;

public class CreationTrace : MonoBehaviour
{
    [SerializeField] private string _nameParameter;
    private Animator _trace;
    private SpriteRenderer _renderer;
    
    public void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _trace = GetComponent<Animator>();
        _renderer.enabled = false;
    }

    public void ChangeState(bool condition)
    {
        _renderer.enabled = condition;
        _trace.SetBool(_nameParameter, condition);
    }
}