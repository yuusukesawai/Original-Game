using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;
    //Unityちゃんを移動させるコンポーネントを入れる（追加）
    private Rigidbody myRigidbody;
    public float speed = 2f;
    //前進後退するための力
    private float forwardForce = 500.0f;
    //左右に移動するための力（追加）
    private float turnForce = 500.0f;
    //左右の移動できる範囲（追加）
    private float movableRange = 1000f;

    // Use this for initialization
    void Start()
    {

       

        //Rigidbodyコンポーネントを取得（追加）
        this.myRigidbody = GetComponent<Rigidbody>();



    }

    // Update is called once per frame
    void Update()
    {

        // マウスがクリックされた場合
        if (Input.GetMouseButtonDown(0))
        {
            // Animatorコンポーネントを取得し、"jumpTrigger"をtrueにする
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }


        //Unityちゃんを矢印キーまたはボタンに応じて左右に移動させる（追加）
        if (Input.GetKey(KeyCode.LeftArrow) && -this.movableRange < this.transform.position.x)
        {
            //左に移動（追加）
            this.myRigidbody.AddForce(-this.turnForce, 0, 0);

            GetComponent<Animator>().SetTrigger("runTrigger");
        }
        else if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < this.movableRange)
        {
            //右に移動（追加）
            this.myRigidbody.AddForce(this.turnForce, 0, 0);
            GetComponent<Animator>().SetTrigger("runTrigger");
        }

        //ユニティちゃんを前進、後退させる
        if(Input.GetKey(KeyCode.DownArrow) && -this.movableRange < this.transform.position.z)
        {
            //前進
            this.myRigidbody.AddForce(0, 0, -this.turnForce);

            GetComponent<Animator>().SetTrigger("runTrigger");
        }
        else if (Input.GetKey(KeyCode.UpArrow) && this.transform.position.z < this.movableRange)
        {
            //後退
            this.myRigidbody.AddForce(0, 0, this.turnForce);

            GetComponent<Animator>().SetTrigger("runTrigger");
        }
    }

    
}