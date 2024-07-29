using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class playreControl : MonoBehaviour
{
    //変数宣言
    public float movespeed = 3;//移動速度
    float leftcoolTime = 0;//クールタイム(比較用)
    float coolTime = 0.7f;//クールタイム(固定値)

    new Rigidbody2D rigidbody2D;
    Animator animator;

    void Start()
    {
        //コンポーネントの取得
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        leftcoolTime -= Time.deltaTime;

        if (leftcoolTime <= 0)
        {
            MoveUpdeta();
            JumpUpdeta();
            AttackUpdeta();
        }
    }

    private void MoveUpdeta()//キャラクターの移動関数
    {
        //キー入力(入力があった場合ボディーに固定のvelosityを代入し続けている。)
        if (Input.GetKey(KeyCode.D))
        {
            
            transform.localScale = new Vector3(-1,1,1);
            rigidbody2D.velocity = new Vector2(1 * movespeed, rigidbody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(1, 1, 1);
            rigidbody2D.velocity = new Vector2(-1 * movespeed, rigidbody2D.velocity.y);
        }

        //アニメーション(GetKeyのboolをifで読み取っている。)
        if(Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.A)==true) 
        {
            animator.SetBool("Rum", true); 
        }else
        {
            animator.SetBool("Rum", false);

            //これがないと滑っていく
            rigidbody2D.velocity = new Vector2(0,rigidbody2D.velocity.y) ;
        }
        

    }

    private void JumpUpdeta()//キャラクターのジャンプ関数
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            float jumpPower = 6.0f;

            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
        }
    }

    private void AttackUpdeta()//キャラクターの攻撃関数
    {
            if (Input.GetMouseButton(0))
            {
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                animator.SetBool("Rum", false);
                animator.SetTrigger("Attack");
                leftcoolTime = coolTime;
                StartCoroutine("Deley");

                
            }
    }
    IEnumerator  Deley()
    {
        yield return new WaitForSeconds(0.3f);
        Vector3 pos = transform.localScale;
        if (pos.x == -1)
        {
            rigidbody2D.velocity = new Vector2(1 * movespeed, rigidbody2D.velocity.y);
        }
        else if (pos.x == 1)
        {
            rigidbody2D.velocity = new Vector2(-1 * movespeed, rigidbody2D.velocity.y);
        }
        leftcoolTime = coolTime;
    }
}
