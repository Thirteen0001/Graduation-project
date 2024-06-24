// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerInputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputAction"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""171700cd-d25b-496d-a1ae-aef4999fe9c7"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""35d848cf-a679-4932-aa04-501d32bd21d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""5afe4ad1-2896-4c35-8cb6-8fdcbe4143a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""d4729fa5-b366-4544-b581-9642a761366b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenBox"",
                    ""type"": ""Button"",
                    ""id"": ""9992befc-f381-4322-b3ce-a8cd3bdc08d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextLevel"",
                    ""type"": ""Button"",
                    ""id"": ""8b7aaacf-10e2-4673-8b3b-91efc281cdbd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShowTip"",
                    ""type"": ""Button"",
                    ""id"": ""1c39743f-a015-4d57-89a8-ed1b80995225"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EnterDoor"",
                    ""type"": ""Button"",
                    ""id"": ""1ec91521-be68-4534-8f30-341ca100d73a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Lower"",
                    ""type"": ""Button"",
                    ""id"": ""3bd9ec12-09ae-4cd7-a902-ee33fa62f16c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenPauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""0406a4f1-4e01-4ea6-91d9-1c11432dd6cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Open_Store"",
                    ""type"": ""Button"",
                    ""id"": ""ae2d408d-e80b-4ff2-8d67-8bb7631e66df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""122b95ce-7244-46b8-bb36-58ed65def40f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0cb34128-a539-480c-8221-6fe11d1cf934"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""32a47f5a-6558-4987-9297-05a7061dd4f9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c4717d77-42c7-4874-90f6-db479fbbc5c4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f5f3aa4a-5afc-46c8-abea-26ca56c2a2e0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""da23f9f0-fc97-4aa7-bba0-32bb366adca5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fec537c5-4509-46e7-a7af-95007e623455"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c301d302-5401-407c-ab58-11a7519c3925"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""714f23f1-6a1d-4ecc-b2e2-7d15de215dfd"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c66cf00d-57f9-4a0c-b36d-dba00e4775c6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e41a8b40-8a26-4b9d-9927-d01c1a039160"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ec45f9a0-0d73-4616-8f15-b036cbce7ccb"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxGamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""34272eb5-03f1-4876-8037-75b58521d44b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxGamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7c28a2c6-4d96-412f-a930-2e164af82700"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxGamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e430a280-57e6-4066-8375-555524382d1b"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxGamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""01f34dc6-a3c6-4272-9b9b-131a438c73af"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d6365cd9-68c9-417c-8081-a13c2f456866"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxGamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6f532485-07f7-43f9-beb8-6b8115dc4160"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxGamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3ed8e9b4-aa27-4028-a09b-aae8eb83efd7"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxGamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""62ad088f-bf94-498a-879d-446f5db4e4fa"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxGamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ac00767b-b4f4-4c52-ac8b-52e1bfada421"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""506a3a16-09d9-4868-97f8-0aa4500b8d5a"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""731b6f06-cf87-4e9e-b167-e86486db2b8a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxGamePad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""651f9544-2c9a-43fa-b834-6b5095a2f5d5"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e64902c-1bf3-4766-b243-ef9026b79d94"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxGamePad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a597526-b869-4b5f-b459-6a6bbe9fda37"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxGamePad"",
                    ""action"": ""OpenBox"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60a95617-dded-40b6-9fbf-00bf0a9bc49d"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""OpenBox"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""932f920d-5b0d-40da-ba20-627e80eafe7c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""NextLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c19c713-1cb7-4d91-afd1-d5d00e9776bc"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxGamePad"",
                    ""action"": ""NextLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73b6d004-2610-4153-9d26-4d4885a53254"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ShowTip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03607252-e7e7-4ba0-88d7-8c999812888d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxGamePad"",
                    ""action"": ""ShowTip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a5ae5be-b017-464b-abae-1a7eb8fccbd6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""EnterDoor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9f65634-c874-4055-b715-a044c61d54ea"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxGamePad"",
                    ""action"": ""EnterDoor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61890987-64b4-4bec-aacc-675cabff188f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Lower"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66beb678-2b5e-46bb-8d01-439344751768"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxGamePad"",
                    ""action"": ""Lower"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""033d1b32-4094-4a92-9eff-52be0c5320fa"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxGamePad"",
                    ""action"": ""Lower"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f3154d0-bc7d-4301-a87d-503bf5136e14"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""OpenPauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7e3527c-dc2c-4001-a6cb-49afd81585d2"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxGamePad"",
                    ""action"": ""OpenPauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f75e2900-9199-40b7-aa37-b01816f662f0"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Open_Store"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38bdf278-93e2-4c57-bfaf-ae2675b09040"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxGamePad"",
                    ""action"": ""Open_Store"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        },
        {
            ""name"": ""XboxGamePad"",
            ""bindingGroup"": ""XboxGamePad"",
            ""devices"": []
        }
    ]
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_Move = m_GamePlay.FindAction("Move", throwIfNotFound: true);
        m_GamePlay_Jump = m_GamePlay.FindAction("Jump", throwIfNotFound: true);
        m_GamePlay_Attack = m_GamePlay.FindAction("Attack", throwIfNotFound: true);
        m_GamePlay_OpenBox = m_GamePlay.FindAction("OpenBox", throwIfNotFound: true);
        m_GamePlay_NextLevel = m_GamePlay.FindAction("NextLevel", throwIfNotFound: true);
        m_GamePlay_ShowTip = m_GamePlay.FindAction("ShowTip", throwIfNotFound: true);
        m_GamePlay_EnterDoor = m_GamePlay.FindAction("EnterDoor", throwIfNotFound: true);
        m_GamePlay_Lower = m_GamePlay.FindAction("Lower", throwIfNotFound: true);
        m_GamePlay_OpenPauseMenu = m_GamePlay.FindAction("OpenPauseMenu", throwIfNotFound: true);
        m_GamePlay_Open_Store = m_GamePlay.FindAction("Open_Store", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Move;
    private readonly InputAction m_GamePlay_Jump;
    private readonly InputAction m_GamePlay_Attack;
    private readonly InputAction m_GamePlay_OpenBox;
    private readonly InputAction m_GamePlay_NextLevel;
    private readonly InputAction m_GamePlay_ShowTip;
    private readonly InputAction m_GamePlay_EnterDoor;
    private readonly InputAction m_GamePlay_Lower;
    private readonly InputAction m_GamePlay_OpenPauseMenu;
    private readonly InputAction m_GamePlay_Open_Store;
    public struct GamePlayActions
    {
        private @PlayerInputAction m_Wrapper;
        public GamePlayActions(@PlayerInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_GamePlay_Move;
        public InputAction @Jump => m_Wrapper.m_GamePlay_Jump;
        public InputAction @Attack => m_Wrapper.m_GamePlay_Attack;
        public InputAction @OpenBox => m_Wrapper.m_GamePlay_OpenBox;
        public InputAction @NextLevel => m_Wrapper.m_GamePlay_NextLevel;
        public InputAction @ShowTip => m_Wrapper.m_GamePlay_ShowTip;
        public InputAction @EnterDoor => m_Wrapper.m_GamePlay_EnterDoor;
        public InputAction @Lower => m_Wrapper.m_GamePlay_Lower;
        public InputAction @OpenPauseMenu => m_Wrapper.m_GamePlay_OpenPauseMenu;
        public InputAction @Open_Store => m_Wrapper.m_GamePlay_Open_Store;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAttack;
                @OpenBox.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOpenBox;
                @OpenBox.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOpenBox;
                @OpenBox.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOpenBox;
                @NextLevel.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNextLevel;
                @NextLevel.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNextLevel;
                @NextLevel.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNextLevel;
                @ShowTip.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnShowTip;
                @ShowTip.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnShowTip;
                @ShowTip.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnShowTip;
                @EnterDoor.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnEnterDoor;
                @EnterDoor.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnEnterDoor;
                @EnterDoor.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnEnterDoor;
                @Lower.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLower;
                @Lower.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLower;
                @Lower.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLower;
                @OpenPauseMenu.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOpenPauseMenu;
                @OpenPauseMenu.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOpenPauseMenu;
                @OpenPauseMenu.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOpenPauseMenu;
                @Open_Store.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOpen_Store;
                @Open_Store.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOpen_Store;
                @Open_Store.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOpen_Store;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @OpenBox.started += instance.OnOpenBox;
                @OpenBox.performed += instance.OnOpenBox;
                @OpenBox.canceled += instance.OnOpenBox;
                @NextLevel.started += instance.OnNextLevel;
                @NextLevel.performed += instance.OnNextLevel;
                @NextLevel.canceled += instance.OnNextLevel;
                @ShowTip.started += instance.OnShowTip;
                @ShowTip.performed += instance.OnShowTip;
                @ShowTip.canceled += instance.OnShowTip;
                @EnterDoor.started += instance.OnEnterDoor;
                @EnterDoor.performed += instance.OnEnterDoor;
                @EnterDoor.canceled += instance.OnEnterDoor;
                @Lower.started += instance.OnLower;
                @Lower.performed += instance.OnLower;
                @Lower.canceled += instance.OnLower;
                @OpenPauseMenu.started += instance.OnOpenPauseMenu;
                @OpenPauseMenu.performed += instance.OnOpenPauseMenu;
                @OpenPauseMenu.canceled += instance.OnOpenPauseMenu;
                @Open_Store.started += instance.OnOpen_Store;
                @Open_Store.performed += instance.OnOpen_Store;
                @Open_Store.canceled += instance.OnOpen_Store;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_XboxGamePadSchemeIndex = -1;
    public InputControlScheme XboxGamePadScheme
    {
        get
        {
            if (m_XboxGamePadSchemeIndex == -1) m_XboxGamePadSchemeIndex = asset.FindControlSchemeIndex("XboxGamePad");
            return asset.controlSchemes[m_XboxGamePadSchemeIndex];
        }
    }
    public interface IGamePlayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnOpenBox(InputAction.CallbackContext context);
        void OnNextLevel(InputAction.CallbackContext context);
        void OnShowTip(InputAction.CallbackContext context);
        void OnEnterDoor(InputAction.CallbackContext context);
        void OnLower(InputAction.CallbackContext context);
        void OnOpenPauseMenu(InputAction.CallbackContext context);
        void OnOpen_Store(InputAction.CallbackContext context);
    }
}
