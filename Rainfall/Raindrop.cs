using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Rainfall {
    internal class Raindrop {

        private float _x;
        private float _y;
        private float _lifetime;
        private float _size;

        private int _radius;
        private byte _alpha;
        float _outlineWidth;

        public float Lifetime { get => _lifetime; }

        public Raindrop(int x, int y) {
            Random rnd = new();
            _x = x;
            _y = y;
            _lifetime = 0;
            _size = rnd.Next(60, 100);
        }

        public void Update() {
            _lifetime += 0.01f;
            _radius = (int)(_size * _lifetime);
            _alpha = (byte)(255 - (byte)(_lifetime * 255));
            _outlineWidth = 8 - (_lifetime * 8);

        }

        public void Draw(RenderWindow window) {
            CircleShape dropShape = new CircleShape(_radius);
            dropShape.FillColor = new Color(255, 255, 255, 0);
            dropShape.OutlineColor = new Color(30, 60, 120, _alpha);
            dropShape.OutlineThickness = _outlineWidth;
            float _centerX = _x - _radius / 2 - _outlineWidth / 4;
            float _centerY = _y - _radius / 2 - _outlineWidth / 4;
            dropShape.Position = new Vector2f(_centerX, _centerY);
            window.Draw(dropShape);
        }


    }
}
