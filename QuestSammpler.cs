using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* QuestSammler bekommt von dir die OBJ_Quest_Atriebute.
 * Ohne die Datei wird sich nicht OBJ_Quest_Atriebute nicht Updaten.
 * 
 * Diese Datei kann dann von QuestMaster verwaltet werden, muss es aber nicht.
 */
public class QuestSammpler : MonoBehaviour
{
    public OBJ_Quest_Atriebute[] OBJ_Quest;
    public string AufgabenAblauf_Reihe_OR_Frei;
    public bool Aktive;
    public void Start()
    {
        Debug.Log("Start");
    }

    void Update()
    {
        
        if (Aktive == true)
        {
            /* Die Aufgaben können Paralel fertig gemacht werden */
            if (AufgabenAblauf_Reihe_OR_Frei == "Frei")
            {
                for (int i = 0; i < OBJ_Quest.Length; i++) /* Gehe alle OBJ durch und schaue ob sie fertig geworden sind */
                {
                    if (OBJ_Quest[i].QuestFertig == false) /* Update nur wenn Quest nicht fertig ist */
                    {
                        if (OBJ_Quest[i].WurdeGetriggert == false) { OBJ_Quest[i].MakeUpdate(); } /* Update OBJ */
                        if (OBJ_Quest[i].WurdeGetriggert == true) /* Wenn Quest fertig wurde */
                        {
                            OBJ_Quest[i].QuestFertig = true;
                            //Debug.Log(OBJ_Quest[i].Name.ToString() + " == " + OBJ_Quest[i].WurdeGetriggert.ToString());
                            OBJ_Quest[i].FertigMitQuest(); /* Wenn Quest Fertig ist Startet .TiggerThisData() */
                        }
                    }
                    
                }

            /* Die Aufgaben müssen in Reihe geamcht werden */
            } else {
                
                for (int i = 0; i < OBJ_Quest.Length; i++) /* Update nur so weit bis zum false */
                {
                    if (OBJ_Quest[i].QuestFertig == false)
                    {
                        if (OBJ_Quest[i].WurdeGetriggert == false) /* Update nur bei false */
                        {
                            OBJ_Quest[i].MakeUpdate();
                            if (OBJ_Quest[i].WurdeGetriggert == true) /* Quest wurde abgeschlossen */
                            {
                                OBJ_Quest[i].QuestFertig = true;
                                //Debug.Log(OBJ_Quest[i].Name.ToString() + " == " + OBJ_Quest[i].WurdeGetriggert.ToString());

                                OBJ_Quest[i].FertigMitQuest(); /* Wenn Quest Fertig ist Startet .TiggerThisData() */

                            }
                            else { break; } /* brak da die Neste Quest erst  fertig sein darf */
                        }
                    }
                }
            }
        }
    }

    private void test()
    {
        Debug.Log("So Viele OBJ gibt es => " + OBJ_Quest.Length.ToString());
        for (int i = 0; i < OBJ_Quest.Length; i++)
        {
            var Text = "OB =>" + OBJ_Quest[i].Name.ToString();
            Debug.Log(Text);

        }
    }
}
