using System.Collections;
using UnityEngine;

using System.Collections.Generic;



    //TODO: refactor Player to support any charecter
    //      by seperating controlles to charecter
    //      Ex: move to charecter -> _animator.SetBool("Run", true); 

    public class PlayerController : MonoBehaviour , IPlayer
    {
        //public PlayerSpecs PlayerSpecs { get; set; }
        private Animator _animator;                              
        private AudioSource _audioSource;
        private IPlayerInput _playerInput;
        private float _resetTime = 0;
        //private AudioManager _audioManager;
        //public FloatVal _health;

        //[SerializeField] private Item _prefabs;
                                        
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _animator = GetComponent<Animator>();
            _playerInput = GetComponent<IPlayerInput>();
            _playerInput.OnFire += Fire;
            //_audioManager = new AudioManager();
        }

        private void Start()
        {
        //List<int> _vals = new List<int>(); 
        //_vals.Add()

       

            //_audioManager.Sounds = PlayerSpecs.Sounds;
            //_audioManager.AudioSource = _audioSource;
            //_health.Value = PlayerSpecs.Health;
        }


        public void GetLavelData(){}
        private void Update()
        {
            #region Up
            if (_playerInput.Up)
            {                
                _animator.SetBool("Walking", true);
                transform.position += transform.forward * 0.7f * Time.deltaTime *1;
                //_audioManager.PlaySound(0,false);
            }
        else
            _animator.SetBool("Walking", false);
        #endregion

        if (_playerInput.PanLeft)        
              _animator.SetBool("Stand", true);
            else
              _animator.SetBool("Stand", false);

        if (_playerInput.PanRight)
            _animator.SetBool("WalkRight", true);
        else
            _animator.SetBool("WalkRight", false);
        
        if (_playerInput.Backword)
            _animator.SetBool("Twist Dance", true);
        else
            _animator.SetBool("Twist Dance", false);

        if (_playerInput.Akey)
            _animator.SetBool("BreakDance", true);
        else
            _animator.SetBool("BreakDance", false);

        if (_playerInput.Jkey)
        {
            _animator.SetBool("Dribble", true);
            transform.position += transform.forward * 3 * Time.deltaTime * 1;
        }
        else
            _animator.SetBool("Dribble", false);

        if (_playerInput.Forward)
        {
            _animator.SetBool("Running", true);
            transform.position += transform.forward * 4 * Time.deltaTime * 1;
        }
        else
            _animator.SetBool("Running", false);

        #region Down
        if (_playerInput.Down)            
                _animator.SetBool("Sit", true);            
            else
                _animator.SetBool("Sit", false);
            #endregion

            #region Right
            if (_playerInput.Right)
                transform.Rotate(transform.up, 1f);
            #endregion

            #region Left
            if (_playerInput.Left)
                transform.Rotate(transform.up, -1f);
            #endregion

            #region Jump
            if (_playerInput.SpaceBar)
            {
                _animator.SetBool("Jump", true);
                //transform.position += transform.forward *  2 * Time.deltaTime;
                //_audioManager.PlaySound(2, false);

            }
            else
                _animator.SetBool("Jump", false);
            #endregion

            #region if Player falls over 
            //if (transform.eulerAngles.z < 300 && transform.eulerAngles.z > 60 
            //    || transform.eulerAngles.x < 300 && transform.eulerAngles.x > 60)
            //{
            //    _resetTime += Time.deltaTime;
            //    if (_resetTime > 3)
            //    {
            //        transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
            //        transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            //        _resetTime = 0f;
            //    }
            //}        
            #endregion
        }

        private bool _oneShot = true;
        private void Fire()
        {
            if (_oneShot)
            {
                //Instantiate(_prefabs.GameObject, transform.position, transform.rotation);
                //StartCoroutine(FinishAction());
                //_audioManager.PlaySound(1, false);
            }
        }
        private IEnumerator FinishAction()
        {
            _oneShot = false;
            yield return new WaitForSeconds(1);
            _oneShot = true;
        }
      
    }
