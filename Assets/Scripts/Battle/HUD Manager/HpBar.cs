using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Battle.HUD_Manager
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private Image healthBar;

       
        public void SetHp(float hpNormalized)
        {
            //health.transform.localScale = new Vector3(hpNormalized, 1f);
            healthBar.fillAmount = hpNormalized;
        }
    }
}
