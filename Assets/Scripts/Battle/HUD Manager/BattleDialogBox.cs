using System.Collections;
using TMPro;
using UnityEngine;

namespace Battle.HUD_Manager
{
    public class BattleDialogBox : MonoBehaviour
    {

        [SerializeField] private TMP_Text dialogText;
        [SerializeField] private int letterPerSecond; 

        public void SetDialog(string dialog)
        {
            dialogText.text = dialog;
        }

        public IEnumerator TypeDialog(string dialog)
        {
            dialogText.text = "";
            foreach (var t in dialog.ToCharArray())
            {
                dialogText.text += t;
                yield return new WaitForSeconds(1f / letterPerSecond);
            }
        }
        
    }
}
