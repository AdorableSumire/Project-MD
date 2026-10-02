using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour{

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private InputActionReference _moveAction;
    [SerializeField, Range(1f, 20f)] private float _speed = 5f;

    private Vector2 _input;
    private void Reset() => _rigidbody = GetComponent<Rigidbody>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
         _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void OnEnable() => _moveAction.action.Enable();
    private void OnDisable() => _moveAction.action.Disable();

    // Update is called once per frame
    private void Update()
    {
        _input = Vector2.ClampMagnitude(_moveAction.action.ReadValue<Vector2>(, 1f);

        if (_sprite != null && Mathf.Abs(_input.x) > 0.01f)
        _sprite.flipX = _input.x <0f;
    }

    private void FixedUpdate()
    {
        var current = _rigidbody.lineVelocity;
        _rigidbody.linearVelocity = new Vector3(_input.x * _speed, current.y, _input.y * _speed);
    }
    
}
