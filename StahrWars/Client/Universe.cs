using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Universe
    {
        Dictionary<string, Sector> sectors = new Dictionary<string, Sector>();
        List<Ship> players = new List<Ship>();
    }

    class Sector
    {
        Dictionary<string, GameObject> gameObjects = new Dictionary<string, GameObject>();

    }
    class GameObject
    {
        int row;
        int col;
        
    }
}
