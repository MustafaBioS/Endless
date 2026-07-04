using UnityEngine;

public class Player : MonoBehaviour
{

    public float playerSpeed = 5f;
    public float horizontalSpeed = 4f;
    public float rightLimit = 3.5f;
    public float leftLimit = -3.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        {
            if (this.gameObject.transform.position.x > leftLimit) 
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        } 
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
        {
            if (this.gameObject.transform.position.x < rightLimit) 
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1);
            }
        }
    }
}
