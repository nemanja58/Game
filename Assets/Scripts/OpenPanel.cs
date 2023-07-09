using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
	public GameObject PanelShop;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Player player = collision.GetComponent<Player>();

		if (player)
		{
			PanelShop.SetActive(true);
		}
	}

	public void ClosePanel()
	{
		PanelShop.SetActive(false);
	}
	public void OpenPan()
	{
		PanelShop.SetActive(true);
	}
}
