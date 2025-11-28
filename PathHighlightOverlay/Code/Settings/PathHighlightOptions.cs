using ColossalFramework;
using ColossalFramework.UI;
using ICities;
using UnityEngine;

namespace PathHighlightOverlay.Code.Settings
{
    public class PathHighlightOptions: IUserMod
    {
       
        public string Name => "Path Highlight Overlay";

        public string Description =>
        "Highlights all pedestrian paths (including invisible ones).";
        

        public void OnSettingsUI(UIHelperBase helper)
        {
            var group = helper.AddGroup("Path Highlight Overlay") as UIHelper;
            if (group == null) return;

            var panel = group.self as UIPanel;
            if (panel == null) return;

            // Label
            var label = panel.AddUIComponent<UILabel>();
            label.text = "Highlight color";

            // HSB slider button
            group.AddSlider("Highlight color", 0f, 1f, 0.1f, 0.5f, (value) => UpdateHue(value));
            //todo: preview the currently selected color by coloring a small box next to the slider

            // Reset button
            group.AddButton("Reset to default", () => { PathHighlightSettings.ResetToDefault(); });
        }

        private void UpdateHue(float value)
        {
            PathHighlightSettings.SetHue(value);
        }
    }
}
