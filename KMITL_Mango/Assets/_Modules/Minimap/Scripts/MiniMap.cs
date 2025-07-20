using StarterAssets;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField] private RectTransform minimapPanel;

    [SerializeField] private List<Transform> teleportList = new List<Transform>();
    private CharacterController currentPlayer_CharacterController;
    private ThirdPersonController currentPlayer_ThirdPersonController;

    private void Start()
    {
        minimapPanel.gameObject.SetActive(false);
    }

    public void OnClick_ToggleMiniMap()
    {
        minimapPanel.gameObject.SetActive(!minimapPanel.gameObject.activeInHierarchy);
    }

    public void OnClick_TeleportToTarget(int targetIndex)
    {
        if (targetIndex >= teleportList.Count) return;

        if(UserReferencePersistent.Instance != null)
        {
            var player = UserReferencePersistent.Instance.PlayerGameObject;

            if (currentPlayer_CharacterController == null || currentPlayer_ThirdPersonController == null)
            {
                currentPlayer_CharacterController = player.GetComponent<CharacterController>();
                currentPlayer_ThirdPersonController = player.GetComponent<ThirdPersonController>();
            }

            currentPlayer_CharacterController.enabled = false;
            currentPlayer_ThirdPersonController.enabled = false;

            player.transform.position = teleportList[targetIndex].transform.position;
            player.transform.rotation = teleportList[targetIndex].transform.rotation;

            currentPlayer_CharacterController.enabled = true;
            currentPlayer_ThirdPersonController.enabled = true;
        }
    }

}
