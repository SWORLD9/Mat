using UnityEngine;

public class Move_Player : MonoBehaviour
{

    [SerializeField] private int SpeedMove;  // скорость перемещения игрока

    [SerializeField] private Joystick _joystick; // Пульт управления

    [SerializeField] private GameObject _respawn;

    [SerializeField] private float _jumpForce;

    private Rigidbody _rb; // Игрока

    private bool _isGrounded = false; // Проверка касается Земли 
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {   // относительно положению джойстика движется игрок * скорость
        _rb.velocity = new Vector3(_joystick.Horizontal * -SpeedMove, _rb.velocity.y, _joystick.Vertical * -SpeedMove);


        if (this.transform.position.y < -0.91) // Если падает - возвращаем в начало
        {

            this.transform.position = _respawn.transform.position;
        }
    }

    //private void OnCollisionEnter(Collision collision)  // Подтверждаем касание
    //{
    //    if (collision.collider.tag == "Ground")
    //    {
    //        _isGrounded = true;
    //    };
    //}




    //public void Jump() // Прыжок игрока
    //{
    //    if (_isGrounded)
    //    {
    //        rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    //        _isGrounded = false;

    //    };
    //}

}
