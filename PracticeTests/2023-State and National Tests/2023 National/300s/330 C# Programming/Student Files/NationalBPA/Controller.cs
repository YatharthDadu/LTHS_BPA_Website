using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NationalBPA
{
    internal interface Controller
    {
        void MoveUp(PictureBox pb, bool cm);
        void MoveDown(PictureBox pb, bool cm);
        void MoveLeft(PictureBox pb, bool cm);
        void MoveRight(PictureBox pb, bool cm);
    }
}
