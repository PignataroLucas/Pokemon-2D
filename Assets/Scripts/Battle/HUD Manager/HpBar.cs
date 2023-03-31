using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.HUD_Manager
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private TMP_Text currentHp, maxHp;
       
        public void SetHp(float hpNormalized)
        {
            //health.transform.localScale = new Vector3(hpNormalized, 1f);
            healthBar.fillAmount = hpNormalized;
        }
        public void SetHp(int _currentHp, int _maxHp)
        {
            currentHp.text = _currentHp.ToString() + "/";
            maxHp.text = _maxHp.ToString();
        }

        public IEnumerator SetHpSmooth(float value)
        {
            float current = healthBar.fillAmount;
            float changeAmount = current - value;

            while (current - value > Mathf.Epsilon)
            {
                current -= changeAmount * Time.deltaTime;
                healthBar.fillAmount = current;
                yield return null;
            }

            healthBar.fillAmount = value;
        }
    }
}
