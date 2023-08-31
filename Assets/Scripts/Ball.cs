using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Threading.Tasks;

public class Ball : MonoBehaviour
{
    public float MoveForce;
    public float MaxV;

    Rigidbody2D rigidbody;

    bool isTrigger; // đã nảy lên khỏi giá đỡ

    int collisionCount = 0;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(rigidbody != null && isTrigger)
        {
            // giới hạn vận tốc
            // clamp giới hạn giá trị của tham số truyền vào, = min nến nhỏ hơn min, = max nếu lớn hơn max
            rigidbody.velocity = new Vector2(Mathf.Clamp(rigidbody.velocity.x,-MaxV,MaxV),Mathf.Clamp(rigidbody.velocity.y,-MaxV,MaxV));
            
        }
    }
    public void Trigger()
    {
        if(rigidbody != null)
        {
            isTrigger = true;
            rigidbody.bodyType = RigidbodyType2D.Dynamic; // đổi nó thành dynamic
            rigidbody.gravityScale = 0; 
            rigidbody.AddForce(new Vector2(MoveForce,MoveForce)); // vector có x và y bằng nhau thì vector ấy có góc so vs trục là 45 độ
            transform.SetParent(null); // set cha của đối tượng là đối tượng nào, ở đây set lại là null để tách quả bóng ra khỏi thanh đỡ

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //// code này đảm bảo cho quả bóng luôn di chuyển 1 góc 45 độ
        //if (collision.gameObject.CompareTag(GameConst.WALL_TAG) ||
        //    collision.gameObject.CompareTag(GameConst.STICKER_TAG) ||
        //    collision.gameObject.CompareTag(GameConst.BRICK_TAG)
        //    )
        //{
            if (rigidbody.velocity.x >= 0 && rigidbody.velocity.y > 0)
            {
                rigidbody.velocity = Vector2.zero;
                rigidbody.AddForce(new Vector2(MoveForce, MoveForce));
            }
            else if (rigidbody.velocity.x <= 0 && rigidbody.velocity.y > 0)
            {
                rigidbody.velocity = Vector2.zero;
                rigidbody.AddForce(new Vector2(-MoveForce, MoveForce));
            }
            else if (rigidbody.velocity.x <= 0 && rigidbody.velocity.y < 0)
            {
                rigidbody.velocity = Vector2.zero;
                rigidbody.AddForce(new Vector2(-MoveForce, -MoveForce));
            }
            else if(rigidbody.velocity.x >= 0 && rigidbody.velocity.y <0)
            {
                rigidbody.velocity = Vector2.zero;
                rigidbody.AddForce(new Vector2(MoveForce, -MoveForce));
            }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (rigidbody.velocity == Vector2.zero) rigidbody.AddForce(Vector2.up);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameConst.DEATH_ZONE_TAG))
        {
            GameGUIManager.Ins.gameOver.Show();
            
        }
    }
}
