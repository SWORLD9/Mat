using UnityEngine;

public class Move_Player : MonoBehaviour
{

    [SerializeField] private int SpeedMove;  // �������� ����������� ������

    [SerializeField] private Joystick _joystick; // ����� ����������

    [SerializeField] private GameObject _respawn;

    [SerializeField] private float _jumpForce;

    private Rigidbody _rb; // ������

    private bool _isGrounded = false; // �������� �������� ����� 
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {   // ������������ ��������� ��������� �������� ����� * ��������
        _rb.velocity = new Vector3(_joystick.Horizontal * -SpeedMove, _rb.velocity.y, _joystick.Vertical * -SpeedMove);


        if (this.transform.position.y < -0.91) // ���� ������ - ���������� � ������
        {

            this.transform.position = _respawn.transform.position;
        }
    }

    //private void OnCollisionEnter(Collision collision)  // ������������ �������
    //{
    //    if (collision.collider.tag == "Ground")
    //    {
    //        _isGrounded = true;
    //    };
    //}




    //public void Jump() // ������ ������
    //{
    //    if (_isGrounded)
    //    {
    //        rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    //        _isGrounded = false;

    //    };
    //}

}
