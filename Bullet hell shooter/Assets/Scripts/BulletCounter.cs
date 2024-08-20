using UnityEngine;
using TMPro;

public class BulletCounter : MonoBehaviour
{
    public TextMeshProUGUI bulletCountText;
    private int bulletCount = 0;

    public void IncrementBulletCount()
    {
        bulletCount++;
        UpdateBulletCountText();
    }


    private void UpdateBulletCountText()
    {
        bulletCountText.text = "Balas disparadas: \n " + bulletCount.ToString();
    }
}
