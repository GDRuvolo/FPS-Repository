using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerController))]
public class PlayerSetup : NetworkBehaviour
{

    [SerializeField]
    Behaviour[] componentsToDisable;

    [SerializeField]
    string remoteLayerName = "RemotePlayer";

    [SerializeField]
    string dontDrawLayerName = "DontDraw";
    [SerializeField]
    GameObject playerGraphics;

    [SerializeField]
    GameObject playerUIPrefab;
    [HideInInspector]
    public GameObject playerUIInstance;

    //Camera sceneCamera;

    void Start()
    {
        //If we don't control the player, disable these components
        if (!isLocalPlayer)
        {
            DisableComponenets();
            AssignRemoteLayer();
        }
        else
        {
            //Commented to add death cam
           // sceneCamera = Camera.main;
           // if (sceneCamera != null)
           // {
           //     sceneCamera.gameObject.SetActive(false);
           // }
            
            // Disable Local Player Graphics
            SetLayerRecursively(playerGraphics, LayerMask.NameToLayer(dontDrawLayerName));

            // Create Player UI
            playerUIInstance = Instantiate(playerUIPrefab);
            playerUIInstance.name = playerUIPrefab.name;

            //Configure PlayerUI
            PlayerUI ui = playerUIInstance.GetComponent<PlayerUI> ();
            if (ui == null)
                Debug.LogError("No PlayerUI component on PlayerUI prefab.");
            ui.SetPlayer(GetComponent<Player>());

            GetComponent<Player>().SetupPlayer();

            string _username = "Loading...";
            if(UserAccountManager.IsLoggedIn)
            {
                _username = UserAccountManager.LoggedIn_Username;
            }
            else
            {
                _username = transform.name;
            }

            CmdSetUserName(transform.name, _username);
        }
        
    }

    [Command]
    void CmdSetUserName (string playerID, string username)
    {
        Player player = GameManager.GetPlayer(playerID);

        if(player != null)
        {
            Debug.Log(username + " has joined!");
            player.username = username;
        }
    }

    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();

        GameManager.RegisterPlayer(_netID, _player);
    }

    void AssignRemoteLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }

    void DisableComponenets()
    {
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
        }
    }

    void OnDisable()
    {
        Destroy(playerUIInstance);

        if(isLocalPlayer)
            GameManager.instance.SetSceneCameraActive(true);

        //Re-enable scene camera
       // if (sceneCamera != null)
       // {
       //     sceneCamera.gameObject.SetActive(true);
       // }

        GameManager.UnregisterPlayer(transform.name);
    }

}
