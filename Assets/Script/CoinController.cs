using UnityEngine;

public class CoinController : MonoBehaviour
{
    // ���ʉ��t�@�C�����C���X�y�N�^�[����w��
    public AudioClip coinSE;

    // �R�C���̎擾�m�F�t���O
    private bool isCollected = false;

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (isCollected) return; // ���łɎ擾�ς݂Ȃ牽�����Ȃ�

        if (collision.CompareTag("Player"))
        {
            isCollected = true; // �t���O���Ă�i�����2��ڈȍ~���u���b�N�j

            // ���ʉ������̏�ōĐ��i�����I�Ɉ�x������j
            AudioSource.PlayClipAtPoint(coinSE, transform.position);

            // �擾����
            Debug.Log("�R�C���擾�I");

            // �J�E���g�𑝂₷
            GameManager.Instance.AddCoin();

            // �R�C��������
            Destroy(gameObject);
        }
    }
}
