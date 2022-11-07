using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Rainfall {
    internal class Rain {

        private RenderWindow _window;
        private int _strength;
        List<Raindrop> _raindrops = new();

        public Rain(RenderWindow window, int strength) {
            _window = window;
            _strength = strength;
        }

        public void Update() {
            if (_raindrops.Count < _strength) {
                Random rnd = new Random();
                int positionX = rnd.Next(0, (int)_window.Size.X);
                int positionY = rnd.Next(0, (int)_window.Size.X);
                Raindrop raindrop = new Raindrop(positionX, positionY);
                _raindrops.Add(raindrop);
            }
            foreach(var raindrop in _raindrops) {
                raindrop.Update();
            }
            for (int i = _raindrops.Count - 1; i >= 0; i--) {
                if (_raindrops[i].Lifetime >= 1) {
                    _raindrops.RemoveAt(i);
                }
            }
        }

        public void Draw() {
            foreach (var raindrop in _raindrops) {
                raindrop.Draw(_window);
            }
        }

    }
}
