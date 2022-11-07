using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Rainfall {

    internal class Program {

        private static void Main(string[] args) {

            VideoMode mode = new VideoMode(VideoMode.DesktopMode.Width, VideoMode.DesktopMode.Height);
            ContextSettings contextSettings = new ContextSettings();
            contextSettings.AntialiasingLevel = 8;
            RenderWindow window = new RenderWindow(mode, "Rainfall", Styles.Fullscreen, contextSettings);
            window.SetVerticalSyncEnabled(true);

            window.Closed += (sender, args) => window.Close();

            Rain rain = new Rain(window, 1000);

            while (window.IsOpen) {
                window.DispatchEvents();
                window.Clear(new Color(10, 30, 60));
                rain.Update();
                rain.Draw();
                window.Display();
                if (Keyboard.IsKeyPressed(Keyboard.Key.Escape)) {
                    window.Close();
                }
            }



        }

    }

}
