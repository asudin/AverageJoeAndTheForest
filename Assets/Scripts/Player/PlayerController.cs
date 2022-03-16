using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField, Tooltip("Player movement speed.")]
    private float _speed = 10.0f;

    [SerializeField, Tooltip("Range on different axis that the player can move.")]
    private float _axisRange = 15f;
    private float _zAxisMinRange = 0f;
    [Space]

    public Animator animator;
    public GameManager GameManager;

    private float _horizontalInput;
    private float _verticalInput;
    [Space]

    [Header("Projectile Settings")]
    [Tooltip("Projectile that the player fires at animals.")]
    public GameObject[] projectilePrefabs;

    [Tooltip("Timer before the player can fire a new projectile.")]
    private float _projectileTime = 1f;
    private float _timer = 0f;

    void Update()
    {
        PlayerMovement();
        FiringProjectile();
    }

    void PlayerMovement()
    {
        //Setting the X axis boundaries for the player not to step off
        if (transform.position.x < -_axisRange || transform.position.x > _axisRange)
        {
            transform.position = new Vector3(transform.position.x < -_axisRange ? -_axisRange : _axisRange, transform.position.y, transform.position.z);
        }

        //Setting the Z axis boundaries for the player not to step off
        if (transform.position.z > _axisRange || transform.position.z < _zAxisMinRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z < _zAxisMinRange ? _zAxisMinRange : _axisRange);
        }

        //Horizontal player movement
        _horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * _horizontalInput * _speed * Time.deltaTime);
        //Player movement and idle animations
        animator.SetFloat("SpeedHorizontal", Mathf.Abs(_horizontalInput));

        //Vertical player movement
        _verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * _verticalInput * _speed * Time.deltaTime);
        //Player movement and idle animations
        animator.SetFloat("SpeedVertical", Mathf.Abs(_verticalInput));
    }

    //Used to call the throwing animation
    void FiringProjectile()
    {
        _timer += Time.deltaTime;

        //_timer before a new projectile can be thrown
        if (Input.GetKeyDown(KeyCode.Space) && _timer > _projectileTime)
        {
            animator.SetTrigger("isShooting");
            animator.SetFloat("Speed", 2);

            Debug.Log($"Fire 1");

            _timer = 0;
        }
    }

    //Fire projectile inside the firing animation
    void FireFood()
    {
        //Create object as randomized gameobject the list of projectiles
        int projectileIndex = Random.Range(0, projectilePrefabs.Length);

        //Creates a projectile at player's position but 1.2f Z axis in front, because of the collisions between player/animal/projectile
        Instantiate(projectilePrefabs[projectileIndex], transform.position + (transform.forward * 1.2f), projectilePrefabs[projectileIndex].transform.rotation);

        Debug.Log($"Fire 2");

        _timer = 0;
    }

    //Destroy player and the object he collided with
    void OnTriggerEnter(Collider other)
    {
        GameManager.GameOver();
    }
}
