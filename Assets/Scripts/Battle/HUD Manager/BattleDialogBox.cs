using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Battle.HUD_Manager
{
    public class BattleDialogBox : MonoBehaviour
    {

        [SerializeField] private TMP_Text dialogText,ppText,typeMoveText;
        [SerializeField] private int letterPerSecond;
        [SerializeField] private GameObject actionSelector , moveSelector , moveDetails;

        [SerializeField] private List<TMP_Text> actionText;
        [SerializeField] private List<TMP_Text> moveText;

        [SerializeField] private Color highlightedColor;

        
        public IEnumerator TypeDialog(string dialog)
        {
            dialogText.text = "";
            foreach (var t in dialog.ToCharArray())
            {
                dialogText.text += t;
                yield return new WaitForSeconds(1f / letterPerSecond);
            }

            yield return new WaitForSeconds(1f);
        }

        public void EnableDialogText(bool enable)
        {
            dialogText.enabled = enable;
        }
        public void EnableActionSelector(bool enable)
        {
            actionSelector.SetActive(enable);
        }
        public void MoveEnableSelector(bool enable)
        {
            moveSelector.SetActive(enable);
            moveDetails.SetActive(enable);
        }

        public void UpdateActionSelection(int selectedAction)
        {
            for (int i = 0; i < actionText.Count; i++)
            {
                actionText[i].color = i == selectedAction ? highlightedColor : Color.black;
            }
        }

        public void SetMoveNames(List<Move> moves)
        {
            for (int i = 0; i < moveText.Count; i++)
            {
                moveText[i].text = i < moves.Count ? moves[i].MoveAttributes.Name : "-";
            }
        }

        public void UpdateMoveSelection(int selectedAction , Move move)
        {
            for (int i = 0; i < moveText.Count; i++)
            {
                moveText[i].color = i == selectedAction ? highlightedColor : Color.black;
            }

            ppText.text = $"PP {move.Pp}/{move.MoveAttributes.Pp}";
            typeMoveText.text = move.MoveAttributes.Type.ToString(); 
        }
        
    }
}
