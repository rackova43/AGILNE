using UnityEngine;

public class GravityControl : MonoBehaviour
{
    // Funkcia, ktorú voláme, keď chceme zapnúť gravitáciu.
    public void EnableGravity()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
}
