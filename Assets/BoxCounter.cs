using UnityEngine.UI;
using UnityEngine;

public class BoxCounter : MonoBehaviour
{
    [SerializeField]
    private Text boxCounterText;
    [SerializeField]
    private int boxCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TrashBox>())
        {
            Debug.Log("Box enter");
            boxCount += 1;
            boxCounterText.text = ("Boxes: " + boxCount.ToString());
            Destroy(other.gameObject, 3);
        }
    }
}
