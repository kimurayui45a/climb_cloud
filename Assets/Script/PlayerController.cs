using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.Mathematics;


public class PlayerController : MonoBehaviour
{

    // 【教本通り】------------------------------------------------------------------

    //Rigidbody2D rigid2D;

    //// ジャンプの強さ
    //float jumpForce = 600.0f;

    //// 歩くときの力
    //float walkForce = 30.0f;

    //// 最大歩行速度
    //float maxWalkSpeed = 2.0f;

    //// 歩行アニメーション用のスプライト配列
    //public Sprite[] walkSprites;

    //// ジャンプ時のスプライト
    //public Sprite jumpSprite;

    //// アニメーション切り替え用の時間管理変数
    //float time = 0;

    //// 現在のスプライトのインデックス
    //int idx = 0;

    //// スプライトの描画コンポーネント
    //SpriteRenderer spriteRenderer;

    //void Start()
    //{
    //    // フレームレートを60FPSに固定
    //    Application.targetFrameRate = 60;

    //    // Rigidbody2D と SpriteRenderer コンポーネントを取得
    //    this.rigid2D = GetComponent<Rigidbody2D>();
    //    this.spriteRenderer = GetComponent<SpriteRenderer>();
    //}

    //void Update()
    //{

    //    // マウス右クリックでジャンプ（地面にいるときのみ）
    //    // linearVelocity：Unity6.0以降の新しい推奨プロパティ
    //    // linearVelocity：float 値として Y方向の速度だけを直接取得できる
    //    if (Input.GetMouseButtonDown(0) &&
    //            this.rigid2D.linearVelocityY == 0)
    //    {
    //        this.rigid2D.AddForce(transform.up * this.jumpForce);
    //    }

    //    // 右方向へ移動（最大速度に達するまでは加速し続ける）
    //    if (this.rigid2D.linearVelocityX < this.maxWalkSpeed)
    //    {
    //        this.rigid2D.AddForce(transform.right * walkForce);
    //    }

    //    // アニメーション
    //    if (this.rigid2D.linearVelocityY != 0)
    //    {
    //        // ジャンプ中はジャンプ用スプライトに切り替え
    //        this.spriteRenderer.sprite = this.jumpSprite;
    //    }
    //    else
    //    {
    //        // 地上では歩行スプライトを交互に切り替えてアニメーション
    //        this.time += Time.deltaTime;
    //        if (this.time > 0.1f)
    //        {
    //            // アニメーションの時間カウントをリセット（次のフレーム切り替えまでのカウント開始）
    //            this.time = 0;

    //            // 現在のインデックス（idx）に対応する歩行スプライトを表示
    //            this.spriteRenderer.sprite = this.walkSprites[this.idx];

    //            // スプライトのインデックスを0と1で交互に切り替え
    //            this.idx = 1 - this.idx;
    //        }
    //    }

    //    // プレイヤーが画面外に落下したらゲームシーンを再読み込み（リスタート）
    //    if (transform.position.y < -10)
    //    {
    //        SceneManager.LoadScene("GameScene");
    //    }
    //}

    //// ゴールに到達
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("ゴール");

    //    // クリア画面に遷移
    //    SceneManager.LoadScene("ClearScene");
    //}

    // 【以上、教本通り】------------------------------------------------------------------




    // 【アレンジ】------------------------------------------------------------------
    Rigidbody2D rigid2D;

    // ジャンプの強さ
    float jumpForce = 320.0f;

    // 歩くときの力
    float walkForce = 30.0f;
    // 最大歩行速度
    float maxWalkSpeed = 2.0f;

    // 歩行アニメーション用のスプライト配列
    public Sprite[] walkSprites;

    // ジャンプ時のスプライト
    public Sprite jumpSprite;

    // アニメーション切り替え用の時間管理変数
    float time = 0;

    // 現在のスプライトのインデックス
    int idx = 0;

    // スプライトの描画コンポーネント
    SpriteRenderer spriteRenderer;

    // ジャンプ時の音
    public AudioClip jumpSE;

    // クリア時の音
    public AudioClip clearSE;

    void Start()
    {
        // フレームレートを60FPSに固定
        Application.targetFrameRate = 60;

        // Rigidbody2D と SpriteRenderer コンポーネントを取得
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        // 上矢印キーでジャンプ（地面にいるときのみ）
        if (Input.GetKeyDown(KeyCode.UpArrow) &&
                this.rigid2D.linearVelocityY == 0)
        {
            // 効果音をその場で再生（自動的に一度だけ鳴る）
            AudioSource.PlayClipAtPoint(jumpSE, transform.position);

            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // velocityを使用する場合
        // velocity：いまオブジェクトが上下方向にどれだけのスピードで動いているかを表す
        //if (Input.GetMouseButtonDown(0) && this.rigid2D.velocity.y == 0)
        //{
        //    this.rigid2D.AddForce(transform.up * this.jumpForce);
        //}


        // 左右キーで移動（力を加える）
        float horizontal = Input.GetAxis("Horizontal");
        if (Mathf.Abs(this.rigid2D.linearVelocityX) < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * horizontal * walkForce);
        }


        // 左右キーに応じてスプライトの向きを変更
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.spriteRenderer.flipX = true; // 左向き
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.spriteRenderer.flipX = false; // 右向き
        }

        // アニメーション（ジャンプ中 or 歩き or 停止）
        if (this.rigid2D.linearVelocityY != 0)
        {
            // ジャンプ中：ジャンプ用スプライトに切り替え
            this.spriteRenderer.sprite = this.jumpSprite;
        }
        else if (horizontal != 0)
        {
            // 左右キーが押されている：歩行アニメーション更新
            this.time += Time.deltaTime;
            if (this.time > 0.1f)
            {
                this.time = 0;
                this.spriteRenderer.sprite = this.walkSprites[this.idx];
                this.idx = 1 - this.idx;
            }
        }
        else
        {
            // 停止中（常にインデックス0番のスプライトを表示）
            this.spriteRenderer.sprite = this.walkSprites[0];
            this.time = 0;
            this.idx = 0;
        }


        // プレイヤーが画面外に落下したらゲームシーンを再読み込み（リスタート）
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }


    // IEnumerator：一定時間待ったり、処理を「途中で止めたり再開」できるメソッドを作るための型
    IEnumerator GoalRoutine()
    {
        // SEを再生
        AudioSource.PlayClipAtPoint(clearSE, transform.position);

        // 少し待ってからシーン遷移（音を鳴らしきる時間）
        yield return new WaitForSeconds(1.0f);

        // クリア画面に遷移
        SceneManager.LoadScene("ClearScene");
    }



    // 他のオブジェクトに衝突したときに呼ばれる
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            Debug.Log("ゴール");

            // コルーチン（処理GoalRoutine）を開始
            StartCoroutine(GoalRoutine());

        }
    }
}
