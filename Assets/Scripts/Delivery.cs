using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    float delayTime = 0.3f;
    SpriteRenderer spriteRenderer;
    public Sprite[] sprites = new Sprite[2];

    bool isPlayerInsideTheTriggerArea;
    GameObject pizza, customer;

    public SpawnController spawnController;

    bool atPizzaArea; 
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];
        spawnController.InstantiateNumber(true);
    }

    void Update()
    {
        if (isPlayerInsideTheTriggerArea)
        {
            if(Input.GetKeyDown(KeyCode.E) && !hasPackage && atPizzaArea)
            {               
                PickUpPizza();
            }
            else if(Input.GetKeyDown(KeyCode.E) && hasPackage && !atPizzaArea)
            {              
                DeliverPizza();
            }
        }
    }

    void PickUpPizza()
    {
        Debug.Log("Order Picked");
        hasPackage = true;
        Destroy(pizza, delayTime);
        isPlayerInsideTheTriggerArea = false;
        Invoke("ChangeCar", delayTime);
        spawnController.InstantiateNumber(false);
        spawnController.isSwapned = null;  

    }

    void DeliverPizza()
    {
        Debug.Log("Order Delivered");
        pizza = null;
        hasPackage = false;
        Destroy(customer, delayTime);
        Invoke("ChangeCar", delayTime);
        spawnController.InstantiateNumber(true);
        spawnController.isSwapned = null;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Pizza"|| collision.gameObject.tag == "Customer")
        {
            if (collision.gameObject.tag == "Pizza")
            {
                if (pizza == null)
                {
                    pizza = collision.gameObject;
                }

                atPizzaArea = true;
            }

            if (collision.gameObject.tag == "Customer")
            {
                if (customer == null)
                {
                    customer = collision.gameObject;
                }
                atPizzaArea = false;
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
