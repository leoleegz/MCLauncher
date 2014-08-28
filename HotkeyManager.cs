using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace MCLauncher
{
    class HotkeyBinded
    {
        public Hotkey Key;
        public Button Btn;
    }

    class HotkeyManager
    {
        static List<HotkeyBinded> keys = new List<HotkeyBinded>();

        public static void AddKeys(Keys keycode, bool shift, bool control, bool alt, Button btn, Control form)
        {
            Hotkey key = new Hotkey(keycode, shift, control, alt, false);
            key.Pressed += new HandledEventHandler(hotkey_Pressed);
            bool regged = key.Register(form);

            if (regged)
            {
                HotkeyBinded bind = new HotkeyBinded();
                bind.Key = key;
                bind.Btn = btn;
                keys.Add(bind);
            }
        }

        public static void Unregister()
        {
            foreach (HotkeyBinded bind in keys)
            {
                if (bind.Key.Registered)
                    bind.Key.Unregister();
            }
        }

        static void hotkey_Pressed(object sender, HandledEventArgs e)
        {
            Hotkey keypressed = (Hotkey)sender;
            foreach (HotkeyBinded bind in keys)
            {
                if (bind.Key.KeyCode == keypressed.KeyCode
                    && bind.Key.Alt == keypressed.Alt
                    && bind.Key.Control == keypressed.Control
                    && bind.Key.Shift == keypressed.Shift)
                {
                    bind.Btn.PerformClick();
                    e.Handled = true;
                    return;
                }
            }
        }
    }
}
