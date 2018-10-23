
using UnityEngine;
using UnityEngine.UI;

// プレイヤー
public class Player : MonoBehaviour
{

    [SerializeField] private Vector3 velocity;              // 移動方向
    [SerializeField] private float moveSpeed = 800.0f;        // 移動速度

    public GameObject cameraRootObj;

    public GameObject AttackArea;

    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        int x = 0;
        int j = 0;

        // マウスがクリックされた場合
        if (Input.GetKey(KeyCode.C))
        {
            j++;
            // Animatorコンポーネントを取得し、"jumpTrigger"をtrueにする
            GetComponent<Animator>().SetBool("jump", true);
        }

        // WASD入力から、XZ平面(水平な地面)を移動する方向(velocity)を得ます
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            x++;
            velocity += new Vector3(cameraRootObj.transform.forward.x, 0, cameraRootObj.transform.forward.z);
            GetComponent<Animator>().SetBool("run", true);
        }


        if (Input.GetKey(KeyCode.A))
        {
            x++;
            velocity += new Vector3(-cameraRootObj.transform.right.x, 0, -cameraRootObj.transform.right.z);
            GetComponent<Animator>().SetBool("run", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            x++;
            velocity += new Vector3(-cameraRootObj.transform.forward.x, 0, -cameraRootObj.transform.forward.z);
            GetComponent<Animator>().SetBool("run", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            x++;
            velocity += new Vector3(cameraRootObj.transform.right.x, 0, cameraRootObj.transform.right.z);
            GetComponent<Animator>().SetBool("run", true);
        }

        if (x == 0)
        {
            GetComponent<Animator>().SetBool("run", false);
        }
        if (j == 0)
        {
            GetComponent<Animator>().SetBool("jump", false);
        }

        //攻撃ボタンの実装
        if (Input.GetKey(KeyCode.E))
        {
            GetComponent<Animator>().SetBool("Attack", true);

            AttackArea.SetActive(true);



        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            GetComponent<Animator>().SetBool("Attack", false);

            AttackArea.SetActive(false);
        }


        // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        // いずれかの方向に移動している場合
        if (velocity.magnitude > 0)
        {
            // プレイヤーの位置(transform.position)の更新
            // 移動方向ベクトル(velocity)を足し込みます
            transform.position += velocity;
        }


        // いずれかの方向に移動している場合
        if (velocity.magnitude > 0)
        {

            // プレイヤーの回転(transform.rotation)の更新
            // 無回転状態のプレイヤーのZ+方向(後頭部)を、移動の方向(velocity)に回す回転とします
            transform.rotation = Quaternion.LookRotation(velocity);

            // プレイヤーの位置(transform.position)の更新
            // 移動方向ベクトル(velocity)を足し込みます
            transform.position += velocity;
        }
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        


        //敵に攻撃が当たった時
        if (other.gameObject.tag == "Enemytag")
        {
            Debug.Log("Hit!");
        }

        
    }
}
