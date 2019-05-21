using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Diese Script wir am ein obj angehant dass zu einer Quest gehört. 
 * Um zu Updaten braucht es ein weiteres obj mit den Script QuestSammler.
 * 
 */
public class OBJ_Quest_Atriebute : MonoBehaviour
{
    public string Name;
    //public TriggerType; <-- Pack hier die cs Datei rein die 
    //public TiggerThisData; <-- Css Datei
    public bool Aktive; /* OBJ darf Update werden */
    public bool QuestFertig; /* OBJ wurde fertig für QuestSammpler */
    public bool WurdeGetriggert; /* Quest wurde fertig */

    public void MakeUpdate()
    {
        if (Aktive == true)
        {   
        /*
            if (TriggerType.IsTrigger() == true) 
            {
                WurdeGetriggert = true;
            }

        */
        }

    }

    public void FertigMitQuest() { /* TiggerThisData(); */ }

}
