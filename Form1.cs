using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Karesz
{
    public partial class Form1 : Form
    {
        void Lépj_hátra()
        {
            Fordulj(jobbra);
            Fordulj(jobbra);
            Lépj();
            Fordulj(jobbra);
            Fordulj(jobbra);
        }

        const int előre = 0; // -1 a balra, 1 a jobbra, 0 lesz az előre.
        void Állj_irányba(int irany)
        {
            if (irany != 0)
            {
                Fordulj(irany);
            }
        }

        bool Léphetek() => !(Van_e_előttem_fal() || Kilépek_e_a_pályáról());

        bool Ha_van_itt_kavics_akkor_idelépek(int irany)
        {
            Állj_irányba(irany);
            if (!Léphetek())
            {
                Állj_irányba(-irany); // -0=0, tehát az előrével nem lesz baj
                return false;
            }
            Lépj();
            if (!Van_e_itt_kavics())
            {
                Lépj_hátra();
                Állj_irányba(-irany);
                return false;
            }
            return true;
        }

        void Kavicskövetés()
        {
            while (Ha_van_itt_kavics_akkor_idelépek(előre) || Ha_van_itt_kavics_akkor_idelépek(jobbra) || Ha_van_itt_kavics_akkor_idelépek(balra)){};
        }



        void FELADAT()
        {
            Kavicskövetés();            
        }     
    }
}