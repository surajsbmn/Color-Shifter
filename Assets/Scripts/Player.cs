using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {

	public float jumpForce = 10f;

	public Rigidbody2D rb;
	public SpriteRenderer sr;

	public string currentColor = null;

	public Color colorCyan;
	public Color colorYellow;
	public Color colorMagenta;
	public Color colorPurple;

    public Text scoreText;
    public static int score=0;

    public GameObject retryUI;

    void Start(){
        Time.timeScale = 0f;
		SetRandomColor();
        score = 0;

    }

	void Update() {
		if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)){
            if (Time.timeScale == 0f)
                Time.timeScale = 1f;
			rb.velocity=Vector2.up*jumpForce;
		}
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag=="Color Changer"){
			SetRandomColor();
			Destroy(col.gameObject);
            score += 1;
            scoreText.text = score.ToString();
			return;
		}
        if (col.tag == "Finish")
        {
            Debug.Log("Game Over");
            Retry.isPlayerWon = true;

            return;
        }
        if (col.tag!=currentColor || col.tag=="Bottom")                 //Game Over Condition
        {
            Debug.Log("Game Over");
            Retry.isGameEnded = true;
            return;
           // retryUI.SetActive(true);
		   //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);// put in retry button event
		}

        if (col.tag == "Finish")
        {
            Debug.Log("Game Over");
            Retry.isPlayerWon = true;
            
            return;
        }
    }

   

    void SetRandomColor(){
		int index = Random.Range(0,4);
		string newColor=null;

		switch(index){
			case 0:
				newColor="Cyan";
				sr.color =colorCyan;
				break;
			case 1:
				newColor="Yellow";
				sr.color =colorYellow;
				break;
			case 2:
				newColor="Magenta";
				sr.color= colorMagenta;
				break;
			case 3:
				newColor="Purple";
				sr.color= colorPurple;
				break;
		}
        currentColor = newColor;
        if (string.Compare(newColor, currentColor)!=0)
			SetRandomColor();
		
	}
}
