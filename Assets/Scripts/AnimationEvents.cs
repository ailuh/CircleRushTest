using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField]
    private GameObject CirclePrefab;
    [SerializeField]
    private float movementSpeed;
    private float StartXPosition;
    private Vector2 StartYPosition;
    [SerializeField]
    private RectTransform Dimensions;

    private void Start()
    {
        var PrefabDimensions = CirclePrefab.GetComponent<RectTransform>().rect;
        StartXPosition = - Dimensions.rect.width / 2 - PrefabDimensions.width / 2;
        StartYPosition = new Vector2(-Dimensions.rect.height / 2 + PrefabDimensions.height / 2, 
                                     Dimensions.rect.height / 2 - PrefabDimensions.height / 2);
    }
    void CheckEvent()
    {
        StartCoroutine(SpawnCircle());
    }

    IEnumerator SpawnCircle()
    {
        GameObject circle = Instantiate(CirclePrefab, gameObject.transform);
        circle.tag = "Circle";
        circle.GetComponent<Image>().color = new Color32((byte)Random.Range(1, 255), (byte)Random.Range(1, 255), (byte)Random.Range(1, 255), 255);
        circle.GetComponent<RectTransform>().localPosition = new Vector3(StartXPosition, Random.Range(StartYPosition.x, StartYPosition.y), 0);
        bool createCircle = true;
        while (circle.GetComponent<RectTransform>().localPosition.x <= -StartXPosition)
        { 
            circle.GetComponent<RectTransform>().position += new Vector3(movementSpeed * Time.deltaTime, 0, 0);
            if (createCircle)
            {
                StartCoroutine(TimeWaiter());
                createCircle = false;
            }
            else
            {
                yield return null;
            }
        }
        Destroy(circle);
    }
    IEnumerator TimeWaiter()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SpawnCircle());
    }


}
