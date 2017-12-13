using System;
using System.Collections.Generic;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml.Input;

namespace NeoSmart.Uwp.ModifierKeys
{
    [Flags]
    public enum ModifierKey
    {
        None,
        Ctrl,
        Alt,
        LeftAlt,
        RightAlt,
        Shift,
        LeftShift,
        RightShift,
        Windows,
        RightWindows,
        LeftWindows
    }

    public static class EventExtensionMethods
    {
        private static (VirtualKey VirtualKey, ModifierKey ModifierKey)[] ModifierMap = new []
        {
            (VirtualKey.Control, ModifierKey.Ctrl),
            (VirtualKey.LeftControl, ModifierKey.Ctrl | ModifierKey.LeftShift),
            (VirtualKey.RightControl, ModifierKey.Ctrl | ModifierKey.RightShift),
            (VirtualKey.Menu, ModifierKey.Alt),
            (VirtualKey.LeftMenu, ModifierKey.Alt | ModifierKey.LeftAlt),
            (VirtualKey.RightMenu, ModifierKey.Alt | ModifierKey.RightAlt),
            (VirtualKey.Shift, ModifierKey.Shift),
            (VirtualKey.LeftShift, ModifierKey.Shift | ModifierKey.LeftShift),
            (VirtualKey.RightShift, ModifierKey.Shift | ModifierKey.RightShift),
            (VirtualKey.LeftWindows, ModifierKey.Windows | ModifierKey.LeftWindows),
            (VirtualKey.RightWindows, ModifierKey.Windows | ModifierKey.RightWindows),
        };

        public static ModifierKey ModifierKeys(this KeyRoutedEventArgs @event)
        {
            ModifierKey modifiers = ModifierKey.None;

            foreach (var modifier in ModifierMap)
            {
                if (CoreWindow.GetForCurrentThread().GetKeyState(modifier.VirtualKey) == CoreVirtualKeyStates.Down)
                {
                    modifiers |= modifier.ModifierKey;
                }
            }

            return modifiers;
        }
    }
}
