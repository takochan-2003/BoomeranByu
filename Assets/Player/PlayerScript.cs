using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject enemy;
    public GameObject gameManager;
    public LifeMager lifeMagerScript;
    public CharacterController characterController;

   

    //�ړ��̍ō����x
    private float maxSpeed = 5.0f;
    //�Œᑬ�x
    private float minSpeed = 2.0f;
    //���񑬓x
    private float turnRate = 7.0f;
    //�x�N�g��
    private Vector3 velocity;

    //������p���[�̒l
    public float throwPower = 0.0f;
    //������p���[�̍Œ�l
    private const float kThrowPower = 13.0f;
    //������p���[�̍ő�l
    private const float maxThrowPower = 30.0f;
    //�u�[�������𓊂���t���O
    public bool throwFlag = true;

    //���G���Ԃ̃t���O
    private bool invincibleFlag = false;
    //���G���Ԃ̌��݃t���[��
    private float invincibleFlame = 0.0f;
    //���G���Ԃ̍ő�t���[��
    private const float maxInvincibleFlame = 1.5f;

    //RenderTggle�̃X�N���v�g���擾
    private RenderTggle renderTggle;

    // Start is called before the first frame update
    void Start()
    {
        //rendertggle���擾
        renderTggle = GetComponent<RenderTggle>();

        //GameManager���擾
        gameManager = GameObject.Find("GameManager");
        lifeMagerScript = gameManager.GetComponent<LifeMager>();

        //�R���g���[���[�擾
        this.characterController = this.GetComponent<CharacterController>();
        //���x��0�ɂ���
        this.velocity = Vector3.zero;


    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Throw();

        TouchEnemy();
    }

    private void Move()
    {
        Vector3 vec = this.velocity;
        //�ړ����x
        float speed = 0.0f;


        ////�L�����N�^�[���n�ʂɐڂ��Ă��邩�𔻒�
        //if (this.characterController.isGrounded)
        //{
        //    //�p�b�h�̃X�e�B�b�N���͂��������Ĉړ��x�N�g�����쐬
        //    vec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //    //���͒l��0.1�ȏ�Ȃ瑬����ݒ�
        //    if (vec.magnitude > 0.1)
        //    {
        //        //�X�e�B�b�N�̓|����ő�����ύX
        //        speed = Mathf.Lerp(this.minSpeed, this.maxSpeed, vec.magnitude);

        //        //�����̕ύX
        //        Vector3 dir = vec.normalized;
        //        float rotate = Mathf.Acos(dir.z);
        //        if (dir.x < 0) rotate = -rotate;
        //        rotate *= Mathf.Rad2Deg;
        //        Quaternion Q = Quaternion.Euler(0, rotate, 0);

        //        //���f���̌�����ύX
        //        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Q, this.turnRate);

        //    }
        //    //�ړ��x�N�g���𐳋K��
        //    vec = vec.normalized;
        //}

        //�p�b�h�̃X�e�B�b�N���͂��������Ĉړ��x�N�g�����쐬
        vec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //���͒l��0.1�ȏ�Ȃ瑬����ݒ�
        if (vec.magnitude > 0.1)
        {
            //�X�e�B�b�N�̓|����ő�����ύX
            speed = Mathf.Lerp(this.minSpeed, this.maxSpeed, vec.magnitude);

            //�����̕ύX
            Vector3 dir = vec.normalized;
            float rotate = Mathf.Acos(dir.z);
            if (dir.x < 0) rotate = -rotate;
            rotate *= Mathf.Rad2Deg;
            Quaternion Q = Quaternion.Euler(0, rotate, 0);

            //���f���̌�����ύX
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Q, this.turnRate);

        }
        //�ړ��x�N�g���𐳋K��
        vec = vec.normalized;

        //�ړ����x��ݒ�
        this.velocity.x = vec.x * speed;
        this.velocity.y = vec.y;
        this.velocity.z = vec.z * speed;

        //�d�͂ɂ�闎����ݒ�
        //this.velocity.y += Physics.gravity.y * Time.deltaTime;


        if (!Input.GetButton("Fire3"))
        {
            //�ړ�������
            this.characterController.Move(this.velocity * Time.deltaTime);
        }
     
    }

    private void Throw()
    {
        if (throwFlag == true)
        {
            //������
            if (Input.GetButton("Fire3"))
            {

                //�{�^�������������Ă��鏈��
                throwPower += 0.03f;
                if (throwPower >= maxThrowPower)
                {
                    throwPower = maxThrowPower;
                }


            }
            else if (Input.GetButtonUp("Fire3"))
            {

                ////�{�^���𗣂�������

                Vector3 position = transform.position;
                Instantiate(bullet, position, Quaternion.identity);

                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                bulletRigidbody.AddForce(transform.forward * 100);

                throwFlag = false;
            }
            else
            {
                throwPower = kThrowPower;
            }
        }

        //Debug.Log(throwFlag);
    }

    private void OnTriggerEnter(Collider other)
    {
        // �G�ɏՓ˂�����G�����ł����Ė��G���Ԃ𔭐�������
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);

            //���G���Ԃ̎��̓_���[�W���󂯂Ȃ�
            if(invincibleFlag == false)
            {
                lifeMagerScript.Damage();
            }
            invincibleFlag = true;
        }
    }

    //�G�ƏՓ˂������̏����i�_���[�W�Ƃ����G���Ԃ̊Ǘ��j
    private void TouchEnemy()
    {
        //���G���Ԃ̏���
        if (invincibleFlag == true)
        {
            renderTggle.OnFlag();
            invincibleFlame += Time.deltaTime;
            if(invincibleFlame >= maxInvincibleFlame)
            {
                invincibleFlag = false;
                invincibleFlame = 0.0f;
            }
        }
        else
        {
            renderTggle.OffFlag();
        }
    }

}
