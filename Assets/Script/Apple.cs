using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottommY = -20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottommY)
        {
            Destroy(this.gameObject);

            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

            apScript.AppleDestoryed();
        }
    }
}
