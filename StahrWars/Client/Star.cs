using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Star
    {
        Random rnd = new Random();
        int col = rnd.Next(0, 16);
        int row = rnd.Next(0, 16);

        //Are solid and will destroy anything that touches it
        public void Destroy(Object o)
        {
            if (o.GetType().Equals("Ship")) {
                if (this.col == o.col && this.row == o.row) {
                    col = -1;
                    row = -1;
                }
            }
        }
  
    }


}
