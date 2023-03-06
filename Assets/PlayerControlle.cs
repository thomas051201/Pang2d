using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControlle : MonoBehaviour
{
    float move;
    float _speed = 5f ;
    private float _nextTime = 0.5f, _delai;
    //position marking where to check for ceilings
    UnityEngine.Sprite _spriteStand, _spriteFire;
    SpriteRenderer _monJoueur;
    Animator animator;
    bool isWalking, isShooting;
    List<GameObject> AmmoList = new List<GameObject>();
    GameObject _spriteAmmo;


    AudioClip blaster;
    AudioSource blasterSource;


    // Start is called before the first frame update
    void Start()
    {
        
        _monJoueur = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        _spriteStand = Resources.Load<Sprite>("Sprite/stand");
        _spriteFire = Resources.Load<Sprite>("Sprite/shot");

        _spriteAmmo = Resources.Load("Sprite/ball") as GameObject;


        blasterSource = this.gameObject.AddComponent<AudioSource>();
        blaster = Resources.Load("audio/blaster") as AudioClip;
    }

    // Update is called once per frame
    void Update()
    {
        bool shot = Input.GetKey(KeyCode.Space);
        bool right = Input.GetKey(KeyCode.D);
        bool left = Input.GetKey(KeyCode.Q);
        isWalking = false;
        isShooting = false;
        animator.enabled = false;
        if (isWalking == false)
        {
            _monJoueur.sprite = _spriteStand;
        }
        //delai du shoot

        //gestion des Input
        if (isShooting == false)
        {
            if (right == true)
            {
                animator.enabled = true;
                _monJoueur.flipX = true;
                transform.Translate(new Vector2(_speed, 0) * Time.deltaTime);
                isWalking = true;
            }
            if (left == true)
            {
                _monJoueur.flipX = false;
                animator.enabled = true;
                transform.Translate(new Vector2(-(_speed), 0) * Time.deltaTime);
                isWalking = true;
            }
        }
        if(shot == true && isWalking == false)
        {
            _monJoueur.sprite = _spriteFire;
            _nextTime += Time.deltaTime;
            if (_nextTime > 0.3f)
            {
                _nextTime = 0;
                shoot();

            }
        }
    }
    void shoot()
    {
        
        isShooting = true;
        Instantiate(_spriteAmmo, new Vector2(transform.position.x,transform.position.y),Quaternion.identity); //point de depard de la ball

        blasterSource.clip = blaster;
        blasterSource.PlayOneShot(blaster, 0.2f);

    }
}
