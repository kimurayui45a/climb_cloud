using UnityEngine;

public class CoinController : MonoBehaviour
{
    // 効果音ファイルをインスペクターから指定
    public AudioClip coinSE;

    // コインの取得確認フラグ
    private bool isCollected = false;

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (isCollected) return; // すでに取得済みなら何もしない

        if (collision.CompareTag("Player"))
        {
            isCollected = true; // フラグ立てる（これで2回目以降をブロック）

            // 効果音をその場で再生（自動的に一度だけ鳴る）
            AudioSource.PlayClipAtPoint(coinSE, transform.position);

            // 取得処理
            Debug.Log("コイン取得！");

            // カウントを増やす
            GameManager.Instance.AddCoin();

            // コインを消す
            Destroy(gameObject);
        }
    }
}
