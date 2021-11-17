using UnityEngine;

[RequireComponent(typeof(Camera))]
public class InteractionWithScreen : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _positionLeftBtn;
    public Vector3 PositionLeftBtn => _positionLeftBtn;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _positionLeftBtn = _camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(_positionLeftBtn.x, _positionLeftBtn.y, 0), 0.2f);
    }
}