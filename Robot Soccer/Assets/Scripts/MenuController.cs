using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    // Use this for initialization
    Animator SidePanelAnimator;
    public GameObject SidePanel;
    public Button HamburgerButton;
    int PanelTriggerHash = Animator.StringToHash("TogglePanel");
    int IdleOutSHash = Animator.StringToHash("Base Layer.IdleOut");

	void Start () {
        SidePanelAnimator = SidePanel.GetComponent<Animator>();
        HamburgerButton.onClick.AddListener(delegate { TogglePanel(); });
	}
	
	// Update is called once per frame
	void Update () {
        //HideIfClickedOutside(SidePanel);
	}

    void TogglePanel()
    {
        SidePanelAnimator.SetTrigger(PanelTriggerHash);
    }

    private void HideIfClickedOutside(GameObject panel)
    {
        if (Input.GetMouseButton(0) && panel.activeSelf &&
            !RectTransformUtility.RectangleContainsScreenPoint(
                panel.GetComponent<RectTransform>(),
                Input.mousePosition,
                Camera.main))
        {
           if(SidePanelAnimator.GetCurrentAnimatorStateInfo(0).fullPathHash == IdleOutSHash)
            {
                TogglePanel();
            }
        }
    }
}
