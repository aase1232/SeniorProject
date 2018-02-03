using UnityEngine;

public class GunBehavior : MonoBehaviour
{

    Vector3 mouse_pos;
    public GameObject bullet;
    public GameObject gun;
    public float speed = 5.0f;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector3 direction = target - gun.transform.position;
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            GameObject projectile = (GameObject)Instantiate(bullet, gun.transform.position, rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
            
        }
    }
}






