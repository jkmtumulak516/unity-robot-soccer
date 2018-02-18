using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Script that handles incoming config details and rendering.
 **/
public class DetailsController : MonoBehaviour {

	CanvasGroup Canvas;
	Text TitleText, CreationText, ModifiedText, DescriptionText;
	// Use this for initialization
	void Start () {
		Canvas = GetComponent<CanvasGroup> ();
		TitleText = GameObject.FindGameObjectWithTag ("TitleText").GetComponent<Text>();
		CreationText = GameObject.FindGameObjectWithTag ("CreatedText").GetComponent<Text>();
		ModifiedText = GameObject.FindGameObjectWithTag ("ModifiedText").GetComponent<Text>();
		DescriptionText = GameObject.FindGameObjectWithTag ("DescriptionText").GetComponent<Text>();
		Hide ();
	}

	/**
	 * Sets the Details Panel invisible
	 **/
	void Hide() {
		Canvas.alpha = 0f; 
		Canvas.blocksRaycasts = false; 
	}

	/**
	 * Sets the Details Panel visible
	 **/
	void Show() { 
		Canvas.alpha = 1f; 
		Canvas.blocksRaycasts = true; 
	}

	/**
	 * Fills the text in Details Panel with the passed Configuration data.
	 **/
	public void FillDetails(Configuration config) {
		TitleText.text = config.Title;
		CreationText.text = config.CreationDateTime.ToString("G");
		ModifiedText.text = config.ModifiedDateTime.ToString("G");
		DescriptionText.text = config.Description;
		Show ();
	}



	
	// Update is called once per frame
	void Update () {
		
	}
}
