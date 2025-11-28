using ColossalFramework;
using UnityEngine;

namespace PathHighlightOverlay.Code.Settings
{
    public static class PathHighlightSettings
    {
        //todo GameSettings: 'PathHighlightOverlay' is not found or cannot be loaded. Make sure to call GameSettings.AddSettingsFile() to register a settings file before using SavedValue(). 

        public const string SETTINGS_FILE_NAME = "PathHighlightOverlay";
        
        private static readonly SavedFloat _hue =
            new SavedFloat("Hue", SETTINGS_FILE_NAME, 0f, true);

        private static bool _registered;
        public static void SetHue(float hue)
        {
            _hue.value = Mathf.Clamp01(hue);
        }

        public static float GetHue() => _hue.value;
        
        public static Color HighlightColor
        {
            get
            {
                RegisterSettings();
                return Color.HSVToRGB(_hue.value, 1f, 1f);;
            }

            set
            {
                Color.RGBToHSV(value, out float hue, out _, out _);
                _hue.value = hue;
            }
        }
        public static void ResetToDefault()
        {
            HighlightColor = new Color(1f, 0f, 1f, 1f);
        }

        private static void RegisterSettings()
        {
            if (_registered) return;

            var file = new SettingsFile();     
            file.fileName = SETTINGS_FILE_NAME;
            GameSettings.AddSettingsFile(file);

            _registered = true;
        }
    }
}