using StardewModdingAPI;
using StardewValley;

namespace MTD.SDV.ZoomKey
{
    /// <summary>
    /// Mod entry class.
    /// </summary>
    public class ModEntry : Mod
    {
        /// <summary>
        /// Entry method
        /// </summary>
        /// <param name="helper">A Mod.. Helper?!</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.Input.ButtonPressed += Input_ButtonPressed;
        }

        private void Input_ButtonPressed(object sender, StardewModdingAPI.Events.ButtonPressedEventArgs e)
        {
            if(!Context.IsWorldReady) { return; }

            switch (e.Button)
            {
                case SButton.Add:
                    Game1.options.zoomLevel += 0.1f;
                    break;
                case SButton.Subtract:
                    // If we zoom out anymore, things get weird... 
                    if ((Game1.options.zoomLevel - 0.1f) > 0.2f)
                    {
                        Game1.options.zoomLevel -= 0.1f;
                    }
                    break;
                case SButton.Multiply:
                    Game1.options.zoomLevel = 1.0f;
                    break;
                default:
                    break;
            }
        }
    }
}
