using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _jumpForse = 5f;
    [SerializeField]
    private float _rotationMultiplayer = 2f;
    [SerializeField]
    private GameObject _menu;

    private Rigidbody2D _rigidbody;
    private int _score = 0;

    public int Score
    {
        get
        {
            return _score;
        }
    }
    public bool IsAlive
    {
        get
        {
            return gameObject.activeSelf;
        }

    }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            _rigidbody.linearVelocityY = _jumpForse;
        }

        transform.rotation = Quaternion.Euler(0f,0f, _rigidbody.linearVelocity.y * _rotationMultiplayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        gameObject.SetActive(false);
        _menu.SetActive(true);
        _score = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _score += 1;
    }
}
    