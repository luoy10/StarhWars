using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Client
{
    class Ship:GameObject
    {
        int row;
        int col;
        int lifePower = 100;
        int shiled = 15;
        int phasors = 50;
        int torpedoes = 15;
        PictureBox panCanvas;
        public int currentShipAngle { get; set; }
        public int currentShipFuel { get; set; }
        public Ship(PictureBox panCanvas, ref int shipAngle, ref int fuel_pods)
        {
           
            this.panCanvas = panCanvas;
            this.currentShipAngle = shipAngle;
            this.currentShipFuel = fuel_pods;
        }

        public string turnNorth(ref int shipAngle)
        {
            if (shipAngle != 0)
            {
                shipAngle = 0;
                panCanvas.Refresh();
                
                return "rn";
            }
            else
            {
                return "mov:n";
            }
        }
        public string turnEast(ref int shipAngle)
        {
            if (shipAngle != 90)
            {
                shipAngle = 90;
                panCanvas.Refresh();

                return "re";
            }
            else
            {
                return "mov:e";
            }
        }
        public string turnSouth(ref int shipAngle)
        {
            if (shipAngle != 180)
            {
                shipAngle = 180;
                panCanvas.Refresh();

                return "rs";
            }
            else
            {
                return "mov:s";
            }
        }
        public string turnWest(ref int shipAngle)
        {
            if (shipAngle != 270)
            {
                shipAngle = 270;
                panCanvas.Refresh();

                return "rw";
            }
            else
            {
                return "mov:w";
            }
        }

        public string fire_phasor() {
            this.phasors --;
            return "fp:" + currentShipAngle;
        }

        public string fire_torpedo() {
            this.torpedoes--;
            return "ft:" + currentShipAngle;
        }

        public string hyperspace(ref int fuel_pods) {
            if (fuel_pods >= 5)
            {
                fuel_pods -= 5;
                panCanvas.Refresh();

                return "hyp";
            }
            else {
                return "hypfail";
            }
                             
        }
    }
}
