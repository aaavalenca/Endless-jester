using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float jumpForce = 600;

    [SerializeField]
    bool isGrounded = false;
    bool holdingRight = false;
    Rigidbody2D rigidbody2D;
    

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                rigidbody2D.AddForce(Vector2.up * jumpForce);
                isGrounded = false;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // se o gameObject deste script (Player) entra em uma
        // colisão contra o collision.gameObject (Ground)
        // muda o status
        if (collision.gameObject.CompareTag("Ground")) {
            if(isGrounded == false)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            // assim, fazemos o spike desaparecer toda vez que é acertado pelo Player (ao qual esse script está aplicado)
            Destroy(collision.gameObject);
        }

    }

}

// Toda vez que tiver gameObject.alguma coisa, é para fazer modificações no gameObject a que estamos aplicando esse script
// Quando chamamos um method, tipo OnCollissionEnter2D, estamos acordando para uma ação que ocorreu, por exemplo,
// nosso objeto se chocou com algo. Ao passar o parâmetro Collision2D collision, significa que collision é o gameObject
// ao qual o nosso gameObject se chocou. Verificamos qual foi o que tocamos ver se a tag bate com alguma. 
