
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball_Controller : MonoBehaviour
{
    public float jumpForce;
    public Rigidbody2D rb; //xy eksen hareketi

    public string currentColor; //def color oluşturdum

    public Color colorCyan;
    public Color colorYellow;
    public Color colorPink;
    public Color colorPurple;

    public SpriteRenderer sr;   //spriterenderer a ulaşıp topun rengine erişebilmek için

    public int star;
    public Text StarText;

    void Start()
    {
        randomColor();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Star")
        {
            star++;
            StarText.text = star.ToString();
            Destroy(col.gameObject);
            return;
        }

        if (col.tag == "ColorChanger" )
        {
            randomColor();
            Destroy(col.gameObject);
            return;
        }
        

        if (col.tag != currentColor)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //restart  
        }

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //fare veya space
        {
            rb.velocity = Vector2.up * jumpForce; 
        }
    }

    void randomColor() //rastgele renk üreten methodum
    {
        int index = Random.Range(0, 3);  // 0 4 arası bir sayıyla renk oluşturacak

        switch (index)
        {
            case 0: currentColor = "Cyan"; //Tag için
                sr.color = colorCyan; //sprite rendererdaki renk ile top rengini eşledim
                break;

            case 1: currentColor = "Yellow";
                sr.color = colorYellow;
                Debug.Log("yellow oldu");
                break;

            case 2: currentColor = "Pink";
                sr.color = colorPink;
                break;

            case 3: currentColor = "Purple";
                sr.color = colorPurple;
                break;
        }
    }
}
