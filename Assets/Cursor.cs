using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Card card1;
    private Card card2;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            Card item = hit.collider?.GetComponent<Card>();
            if (item != null)
            {
                item.StartRotation();
                
                if(card1 == null) card1 = item;
                else if(card1 != null && card2 == null) card2 = item;             
                else
                {
                    if (card1.equals(card2)) 
                    { 
                        Debug.Log("равны"); 
                    }
                    else { 
                        Debug.Log("не равны"); 
                    }
                    card1 = card2 = null;
                }
            }
        }
    }
}
