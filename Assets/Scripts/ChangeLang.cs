/* using System.Collections.Generic;
using UnityEngine;

public class ChangeLang : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> engObjects;
    [SerializeField]
    private List<GameObject> rusObjects;
    [SerializeField]
    private List<GameObject> engPanels;
    [SerializeField]
    private List<GameObject> rusPanels;

    void Start()
    {
        
        if (Language.Instance.CurrentLanguage == "ru")
        {
            SetActiveObjects(rusObjects, true);
            SetActiveObjects(rusPanels, true);
        }
        else
        {
            SetActiveObjects(engObjects, true);
            SetActiveObjects(engPanels, true);
        }
    }

    private void SetActiveObjects(List<GameObject> objects, bool state)
    {
        foreach (var obj in objects)
        {
            if (obj != null)
                obj.SetActive(state);
        }
    }
}
*/