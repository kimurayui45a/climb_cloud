using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.Mathematics;


public class PlayerController : MonoBehaviour
{

    // �y���{�ʂ�z------------------------------------------------------------------

    //Rigidbody2D rigid2D;

    //// �W�����v�̋���
    //float jumpForce = 600.0f;

    //// �����Ƃ��̗�
    //float walkForce = 30.0f;

    //// �ő���s���x
    //float maxWalkSpeed = 2.0f;

    //// ���s�A�j���[�V�����p�̃X�v���C�g�z��
    //public Sprite[] walkSprites;

    //// �W�����v���̃X�v���C�g
    //public Sprite jumpSprite;

    //// �A�j���[�V�����؂�ւ��p�̎��ԊǗ��ϐ�
    //float time = 0;

    //// ���݂̃X�v���C�g�̃C���f�b�N�X
    //int idx = 0;

    //// �X�v���C�g�̕`��R���|�[�l���g
    //SpriteRenderer spriteRenderer;

    //void Start()
    //{
    //    // �t���[�����[�g��60FPS�ɌŒ�
    //    Application.targetFrameRate = 60;

    //    // Rigidbody2D �� SpriteRenderer �R���|�[�l���g���擾
    //    this.rigid2D = GetComponent<Rigidbody2D>();
    //    this.spriteRenderer = GetComponent<SpriteRenderer>();
    //}

    //void Update()
    //{

    //    // �}�E�X�E�N���b�N�ŃW�����v�i�n�ʂɂ���Ƃ��̂݁j
    //    // linearVelocity�FUnity6.0�ȍ~�̐V���������v���p�e�B
    //    // linearVelocity�Ffloat �l�Ƃ��� Y�����̑��x�����𒼐ڎ擾�ł���
    //    if (Input.GetMouseButtonDown(0) &&
    //            this.rigid2D.linearVelocityY == 0)
    //    {
    //        this.rigid2D.AddForce(transform.up * this.jumpForce);
    //    }

    //    // �E�����ֈړ��i�ő呬�x�ɒB����܂ł͉�����������j
    //    if (this.rigid2D.linearVelocityX < this.maxWalkSpeed)
    //    {
    //        this.rigid2D.AddForce(transform.right * walkForce);
    //    }

    //    // �A�j���[�V����
    //    if (this.rigid2D.linearVelocityY != 0)
    //    {
    //        // �W�����v���̓W�����v�p�X�v���C�g�ɐ؂�ւ�
    //        this.spriteRenderer.sprite = this.jumpSprite;
    //    }
    //    else
    //    {
    //        // �n��ł͕��s�X�v���C�g�����݂ɐ؂�ւ��ăA�j���[�V����
    //        this.time += Time.deltaTime;
    //        if (this.time > 0.1f)
    //        {
    //            // �A�j���[�V�����̎��ԃJ�E���g�����Z�b�g�i���̃t���[���؂�ւ��܂ł̃J�E���g�J�n�j
    //            this.time = 0;

    //            // ���݂̃C���f�b�N�X�iidx�j�ɑΉ�������s�X�v���C�g��\��
    //            this.spriteRenderer.sprite = this.walkSprites[this.idx];

    //            // �X�v���C�g�̃C���f�b�N�X��0��1�Ō��݂ɐ؂�ւ�
    //            this.idx = 1 - this.idx;
    //        }
    //    }

    //    // �v���C���[����ʊO�ɗ���������Q�[���V�[�����ēǂݍ��݁i���X�^�[�g�j
    //    if (transform.position.y < -10)
    //    {
    //        SceneManager.LoadScene("GameScene");
    //    }
    //}

    //// �S�[���ɓ��B
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("�S�[��");

    //    // �N���A��ʂɑJ��
    //    SceneManager.LoadScene("ClearScene");
    //}

    // �y�ȏ�A���{�ʂ�z------------------------------------------------------------------




    // �y�A�����W�z------------------------------------------------------------------
    Rigidbody2D rigid2D;

    // �W�����v�̋���
    float jumpForce = 320.0f;

    // �����Ƃ��̗�
    float walkForce = 30.0f;
    // �ő���s���x
    float maxWalkSpeed = 2.0f;

    // ���s�A�j���[�V�����p�̃X�v���C�g�z��
    public Sprite[] walkSprites;

    // �W�����v���̃X�v���C�g
    public Sprite jumpSprite;

    // �A�j���[�V�����؂�ւ��p�̎��ԊǗ��ϐ�
    float time = 0;

    // ���݂̃X�v���C�g�̃C���f�b�N�X
    int idx = 0;

    // �X�v���C�g�̕`��R���|�[�l���g
    SpriteRenderer spriteRenderer;

    // �W�����v���̉�
    public AudioClip jumpSE;

    // �N���A���̉�
    public AudioClip clearSE;

    void Start()
    {
        // �t���[�����[�g��60FPS�ɌŒ�
        Application.targetFrameRate = 60;

        // Rigidbody2D �� SpriteRenderer �R���|�[�l���g���擾
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        // ����L�[�ŃW�����v�i�n�ʂɂ���Ƃ��̂݁j
        if (Input.GetKeyDown(KeyCode.UpArrow) &&
                this.rigid2D.linearVelocityY == 0)
        {
            // ���ʉ������̏�ōĐ��i�����I�Ɉ�x������j
            AudioSource.PlayClipAtPoint(jumpSE, transform.position);

            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // velocity���g�p����ꍇ
        // velocity�F���܃I�u�W�F�N�g���㉺�����ɂǂꂾ���̃X�s�[�h�œ����Ă��邩��\��
        //if (Input.GetMouseButtonDown(0) && this.rigid2D.velocity.y == 0)
        //{
        //    this.rigid2D.AddForce(transform.up * this.jumpForce);
        //}


        // ���E�L�[�ňړ��i�͂�������j
        float horizontal = Input.GetAxis("Horizontal");
        if (Mathf.Abs(this.rigid2D.linearVelocityX) < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * horizontal * walkForce);
        }


        // ���E�L�[�ɉ����ăX�v���C�g�̌�����ύX
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.spriteRenderer.flipX = true; // ������
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.spriteRenderer.flipX = false; // �E����
        }

        // �A�j���[�V�����i�W�����v�� or ���� or ��~�j
        if (this.rigid2D.linearVelocityY != 0)
        {
            // �W�����v���F�W�����v�p�X�v���C�g�ɐ؂�ւ�
            this.spriteRenderer.sprite = this.jumpSprite;
        }
        else if (horizontal != 0)
        {
            // ���E�L�[��������Ă���F���s�A�j���[�V�����X�V
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
            // ��~���i��ɃC���f�b�N�X0�Ԃ̃X�v���C�g��\���j
            this.spriteRenderer.sprite = this.walkSprites[0];
            this.time = 0;
            this.idx = 0;
        }


        // �v���C���[����ʊO�ɗ���������Q�[���V�[�����ēǂݍ��݁i���X�^�[�g�j
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }


    // IEnumerator�F��莞�ԑ҂�����A�������u�r���Ŏ~�߂���ĊJ�v�ł��郁�\�b�h����邽�߂̌^
    IEnumerator GoalRoutine()
    {
        // SE���Đ�
        AudioSource.PlayClipAtPoint(clearSE, transform.position);

        // �����҂��Ă���V�[���J�ځi����炵���鎞�ԁj
        yield return new WaitForSeconds(1.0f);

        // �N���A��ʂɑJ��
        SceneManager.LoadScene("ClearScene");
    }



    // ���̃I�u�W�F�N�g�ɏՓ˂����Ƃ��ɌĂ΂��
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            Debug.Log("�S�[��");

            // �R���[�`���i����GoalRoutine�j���J�n
            StartCoroutine(GoalRoutine());

        }
    }
}
