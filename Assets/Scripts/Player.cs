using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite[] sprites;
    private int spriteIndex;
    private Vector3 direction;
    public float garvity = -9.8f;
    public float strength = 5f;
    AudioManager audioManager;
    public GameObject PanelPause;


    private void Awake()
    {
        
        PanelPause.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }
    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            audioManager.PlaySFX(audioManager.jump);
            direction = Vector3.up * strength;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
                direction = Vector3.up * strength;
            }
        }

        direction.y += garvity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;

            PanelPause.SetActive(true);
        }
    }
    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "OFF")
        {
            if (audioManager != null)
            {
                audioManager.PlaySFX(audioManager.death);
            }

            SceneManager.LoadScene("mainmenu");
        }
        else if (other.gameObject.tag == "Kon")
        {
            if (audioManager != null)
            {

                audioManager.PlaySFX(audioManager.point);
            }

            FindObjectOfType<GameManager2>().IncreaseScore();
        }
    }

    public void lanjutkan()
    {
        Time.timeScale = 1f;

        PanelPause.SetActive(false);
    }

    public void keluar()
    {

       
        SceneManager.LoadScene("mainmenu");
    }

}
