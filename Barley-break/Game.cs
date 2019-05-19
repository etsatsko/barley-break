using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barley_break
{
    class Game
    {
        int size = 4;
        int[,] map;
        int spaceX;
        int spaceY;

        public Game()
        {
            map = new int[size, size];
        }

        public void Start ()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    map[x, y] = ConvertCoordsToPosition(x, y) + 1;
            spaceX = size - 1;
            spaceY = size - 1;
            map[spaceX, spaceY] = 0;
        }

        public int GetNumber(int position)
        {
            int x, y;
            ConvertPositionToCoords(position, out x, out y);
            if (x < 0 || x >= size) return 0;
            if (y < 0 || y >= size) return 0;
            return map[x, y];
        }

        public void Shift(int position)
        {
            int x, y;
            ConvertPositionToCoords(position, out x, out y);
            if (Math.Abs(spaceX - x) + Math.Abs(spaceY - y) != 1)
                return;
            map[spaceX, spaceY] = map[x, y];
            map[x, y] = 0;
            spaceX = x;
            spaceY = y;
        }

        private int ConvertCoordsToPosition (int x, int y)
        {
            return y * size + x;
        }

        private void ConvertPositionToCoords(int position, out int x, out int y)
        {
            x = position % size;
            y = position / size;
        }
    }
}
