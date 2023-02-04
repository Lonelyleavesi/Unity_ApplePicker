using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class ApplePicker : MonoBehaviour
{
    public GameObject baseketPrefab;

    public int numBaskets = 3;

    public float basketBottomY = -14f;

    public float basketSpacingY = 2f;

    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>(); 
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGo = Instantiate(baseketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos;

            basketList.Add(tBasketGo);
        }

        activeFirstBasket();
    }

    private void activeFirstBasket()
    {
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGo = basketList[basketIndex];
     
        UnityEngine.Object obj = AssetDatabase.LoadMainAssetAtPath("Assets/Material/Mat_Basket_First.mat");
        Material mat = obj as Material;
        tBasketGo.GetComponent<Renderer>().material = mat;

        Basket basket = tBasketGo.GetComponent<Basket>();
        basket.enable = true;

        tBasketGo.layer = LayerMask.NameToLayer("Basket");
     
    }

    public void AppleDestoryed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tApple in tAppleArray)
        {
            Destroy(tApple);
        }

        // 消除一个篮筐 ，把下面的篮筐置为可用的
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGo = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGo);

        activeFirstBasket();
    }
}
