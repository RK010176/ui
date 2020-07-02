using UnityEngine;
using UnityEngine.UI;

public class SelectionController : MonoBehaviour
{
    public Button Right;
    public Button Left;
    public Transform Container;
    public RectTransform ContentRect;
    private ScrollRect _scrollRect;
    private int CurrentItem = 0;
    private float _contentWidth;
    private float _ItemCenter;

    private void Awake()
    {
        _scrollRect = Container.gameObject.GetComponent<ScrollRect>();
    }


    private void Start()
    {
        print(ContentRect.offsetMin.x - ContentRect.offsetMax.x);
        print((ContentRect.offsetMin.x - ContentRect.offsetMax.x) / ContentRect.transform.childCount);

        _contentWidth = ContentRect.offsetMin.x - ContentRect.offsetMax.x;
        _ItemCenter = Mathf.Abs((ContentRect.offsetMin.x - ContentRect.offsetMax.x) / (ContentRect.transform.childCount-1));
    }


    public void MoveRight()
    {

        ContentRect.offsetMax = Vector2.Lerp(ContentRect.offsetMax, new Vector2(ContentRect.offsetMax.x + (_ItemCenter), 0f), 1);
        ContentRect.offsetMin = Vector2.Lerp(ContentRect.offsetMin, new Vector2(ContentRect.offsetMin.x + (_ItemCenter), 0f), 1);

        //ContentRect.offsetMin = new Vector2(ContentRect.offsetMin.x + (_ItemCenter), 0f);
        //ContentRect.offsetMax = new Vector2(ContentRect.offsetMax.x + (_ItemCenter), 0f);
        //print("min "+ContentRect.offsetMin.x);
        //print("max " + ContentRect.offsetMax.x);
    }

    public void MoveLeft()
    {
        ContentRect.offsetMax = Vector2.Lerp(ContentRect.offsetMax, new Vector2(ContentRect.offsetMax.x - (_ItemCenter), 0f), 1);
        ContentRect.offsetMin = Vector2.Lerp(ContentRect.offsetMin, new Vector2(ContentRect.offsetMin.x - (_ItemCenter), 0f), 1);
        //ContentRect.offsetMin = new Vector2(ContentRect.offsetMin.x - (_ItemCenter), 0f);
        //ContentRect.offsetMax = new Vector2(ContentRect.offsetMax.x - (_ItemCenter), 0f);
        //print("min " + ContentRect.offsetMin.x);
        //print("max " + ContentRect.offsetMax.x);
    }

    ///*Left*/   rectTransform.offsetMin.x;
    ///*Right*/  rectTransform.offsetMax.x;
    ///*Top*/    rectTransform.offsetMax.y;
    ///*Bottom*/ rectTransform.offsetMin.y;
    ///

    
}
