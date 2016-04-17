// This script is an example of a tooltip system

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tooltip : MonoBehaviour {

	public GameObject tooltip;
	public Vector2 offsetFromSlot;
	public float waitTimeTillVisible;


	void Start () {
		Slot.OnInspectedChange += RefreshTooltip;
	}
	
	void RefreshTooltip () {
		if (Slot.inspectedSlot == null || !Slot.inspectedSlot.Populated) {
			StopAllCoroutines();
			StartCoroutine("FadeTooltip",false);
			return;
		}

		StopAllCoroutines();
		StartCoroutine("FadeTooltip",true);
	}

	// This function refreshes the text inside the tooltip graphics depending on the inspected item
	void RefreshText () {
		Text text = tooltip.GetComponentInChildren<Text>();
		if (Slot.inspectedSlot.Populated)
			text.text = "<b>" + Slot.inspectedSlot.ItemName + "</b>" +
								"\n" + "Force : " + "<color=green>" + Slot.inspectedSlot.GetItemAttribute("Force").ToString() + "</color>" + 
								"\n" + "Agility : " + "<color=green>"+ Slot.inspectedSlot.GetItemAttribute("Agility").ToString() + "</color>" + 
								"\n" + "Constitution : " + "<color=green>" + Slot.inspectedSlot.GetItemAttribute("Constitution").ToString() + "</color>" +
								"\n" + "Damage min : " + "<color=green>" + Slot.inspectedSlot.GetItemAttribute("Damage min").ToString() + "</color>" + 
								"\n" + "Damage max : " + "<color=green>" + Slot.inspectedSlot.GetItemAttribute("Damage max").ToString() + "</color>" + 
								"\n" + "Speed : " + "<color=green>" + Slot.inspectedSlot.GetItemAttribute("Speed").ToString() + "</color>" + 
								"\n\n\n" + Slot.inspectedSlot.ItemDescription;
	}


	// This coroutine toggles the tooltip graphics ON / OFF depending on the  "toggle" parameter
	IEnumerator FadeTooltip (bool toggle) {
		yield return new WaitForSeconds(waitTimeTillVisible);
		try {
			tooltip.transform.position = Slot.inspectedSlot.transform.position + new Vector3(offsetFromSlot.x,offsetFromSlot.y,0);
		} catch {}
		tooltip.SetActive(toggle);
		if (toggle)
			RefreshText();
	}
}
