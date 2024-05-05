using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    float delayTime = 0.3f;
    SpriteRenderer spriteRenderer;
    public Sprite[] sprites = new Sprite[2];

    bool isPlayerInsideTheTriggerArea;
    GameObject pizza;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];
    }

    void Update()
    {
        if (isPlayerInsideTheTriggerArea)
        {
            if(Input.GetKeyDown(KeyCode.E) && !hasPackage)
            {               
                PickUpPizza();
            }
            else if(Input.GetKeyDown(KeyCode.E) && hasPackage)
            {              
                DeliverPizza();
            }
        }
    }

    void PickUpPizza()
    {
        hasPackage = true;
        Destroy(pizza, delayTime);
        isPlayerInsideTheTriggerArea = false;
        Invoke("ChangeCar", delayTime);        
    }

    void DeliverPizza()
    {
        hasPackage = false;
        Invoke("ChangeCar", delayTime);       
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Pizza"|| collision.gameObject.tag == "Customer")
        {
            if (collision.gameObject.tag == "Pizza")
            {
                pizza = collision.gameObject;
            }

            isPlayerInsideTheTriggerArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            isPlayerInsideTheTriggerArea = false;
        }
    }

    void ChangeCar()
    {
        if(hasPackage)
        {
            spriteRenderer.sprite = sprites[1];
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
        }
    }

}
