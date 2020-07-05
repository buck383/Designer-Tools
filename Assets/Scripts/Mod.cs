namespace Assets.Scripts {
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System;
    using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
    using Assets.Scripts.DesignerTools;
    using Assets.Scripts.Tools;
    using ModApi.Common;
    using ModApi.Craft.Parts;
    using ModApi.Design;
    using ModApi.GameLoop.Interfaces;
    using ModApi.GameLoop;
    using ModApi.Mods;
    using ModApi.Scenes.Events;
    using ModApi;
    using UnityEngine;

    /// <summary>
    /// A singleton object representing this mod that is instantiated and initialize when the mod is loaded.
    /// </summary>
    public class Mod : ModApi.Mods.GameMod {
        private PartSelectorManager _PartSelectorManager = new PartSelectorManager ();
        public List<ReferenceImage> ReferenceImages = new List<ReferenceImage> ();
        public string RefImagePath = Application.persistentDataPath + "/UserData/DesignerTools/ReferenceImages/";

        /// <summary>
        /// Prevents a default instance of the <see cref="Mod"/> class from being created.
        /// </summary>
        private Mod () : base () { }

        /// <summary>
        /// Gets the singleton instance of the mod object.
        /// </summary>
        /// <value>The singleton instance of the mod object.</value>
        public static Mod Instance { get; } = GetModInstance<Mod> ();

        protected override void OnModInitialized () {
            base.OnModInitialized ();
            Ui.Designer.DesignerToolsUIController.Initialize ();
            System.IO.Directory.CreateDirectory (RefImagePath);
        }

        public void OnViewPanelClosed (List<ReferenceImage> referenceImages) {
            ReferenceImages = referenceImages;
        }
    }
}