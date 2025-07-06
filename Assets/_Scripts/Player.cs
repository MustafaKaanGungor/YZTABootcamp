using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    public float speed;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 inputVector = new Vector3(x, 0, y);

        controller.Move(inputVector * speed);
    }
}
