using TMPro;
using UnityEngine;

namespace Battle.HUD_Manager
{
    public class BattleDialogBox : MonoBehaviour
    {

        [SerializeField] private TMP_Text dialogText;


        public void SetDialog(string dialog)
        {
            dialogText.text = dialog;
        }
        
    }
}
