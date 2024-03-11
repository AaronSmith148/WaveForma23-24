using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class TouchInputManager : MonoBehaviour
{
    public Camera cam;
    public LayerMask ignoreLayer;

    [Header("Test Objects")]
    public GameObject testGameObject;
    public TextMeshProUGUI screenSizeText;
    public TextMeshProUGUI touchPositionText;    

    [Header("VFXs")]
    public List<GameObject> vfxPrefabs = new List<GameObject>();
    public float vfxMaxDuration = 30f;

    [Header ("UI")]
    public GameObject mainUIPanel;
    public GameObject openUIButton;
    public GameObject sceneSwitchPanel;
    public TextMeshProUGUI selectedVFXText;
    public Slider vfxSelectionSlider;
    public TextMeshProUGUI durationVFXText;
    public Slider vfxDurationSlider;

    private bool scenePanelWasOpen = false;
    
    // Start is called before the first frame update
    void Start()
    {
        screenSizeText.text = "Screen Width: " + Screen.width.ToString();
        vfxSelectionSlider.maxValue = vfxPrefabs.Count - 1;
        vfxDurationSlider.maxValue = vfxMaxDuration;
        UpdateSelectedVFXText();
    }

    // Update is called once per frame
    void Update()
    {
        // selectedVFXText.text = "Slider Value: " + vfxSelectionSlider.value;
        if (vfxDurationSlider.value == 1) {
            durationVFXText.text = "Duration: " + vfxDurationSlider.value + " second";
        }
        else {
            durationVFXText.text = "Duration: " + vfxDurationSlider.value + " seconds";
        }

        // Quit Function
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            QuitApplication();
        }
        
        // Touch Functionality
        if (Input.GetMouseButtonDown(0) && !IsPointerOverUI())
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // This checks to see if the ray hits somehting and if the raycast did not something with the layer UI
            if (Physics.Raycast(ray, out hit) && ((1 << hit.collider.gameObject.layer) & ignoreLayer) == 0)
            {
                // Find and record touch position
                Vector3 touchPoint = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                touchPositionText.text = touchPoint.ToString();

                // Spawn Sydney's VFX effect as a prefab
                int vfxIndex = (int)vfxSelectionSlider.value;
                GameObject vfxObject = InstantiateVFX(touchPoint, vfxIndex);
                Destroy(vfxObject, vfxDurationSlider.value);           
            }
        }
    }

    bool IsPointerOverUI() {
        return EventSystem.current.IsPointerOverGameObject();
    }

    GameObject InstantiateVFX(Vector3 position, int vfxIndex) {
        GameObject vfxPrefab = vfxPrefabs[vfxIndex];
        GameObject vfxObject = Instantiate(vfxPrefab, position + vfxPrefab.transform.localPosition, Quaternion.identity);
        VisualEffect visualEffect = vfxObject.GetComponent<VisualEffect>();
        if (visualEffect != null)
        {
            visualEffect.Play();
        }
        return vfxObject;
    }

    // Make sure to assign this function to the slider you have in the Hierarchy
    void UpdateSelectedVFXText() {
        int vfxIndex = (int)vfxSelectionSlider.value;
        string selectedVFXName = vfxPrefabs[vfxIndex].name; 
        selectedVFXText.text = "Selected VFX: " + selectedVFXName; 
        // Debug.Log("Update Selection Slider: " + selectedVFXName);
    }

    public void OnVFXSliderValueChanged() {
        // Debug.Log("Slider value changed");
        UpdateSelectedVFXText(); // Update the selected VFX text when the slider value changes
    }

    public void ToggleMainPanel() {
        mainUIPanel.SetActive(!mainUIPanel.activeSelf);
        openUIButton.SetActive(!openUIButton.activeSelf);

        // Saves the state of if the panel was open too
        if (!mainUIPanel.activeSelf && sceneSwitchPanel.activeSelf) {
            sceneSwitchPanel.SetActive(false);
        }
        else if (mainUIPanel.activeSelf && scenePanelWasOpen) {
            sceneSwitchPanel.SetActive(true);
        }
    }

    public void ToggleScenePanel() {
        sceneSwitchPanel.SetActive(!sceneSwitchPanel.activeSelf);

        scenePanelWasOpen = sceneSwitchPanel.activeSelf;
    }

    public void SwitchScene(string Scene) {
        Debug.Log("SceneSwitch was pressed");
        SceneManager.LoadScene(Scene);
    }

    public void QuitApplication() {
        Application.Quit();
    }
}
