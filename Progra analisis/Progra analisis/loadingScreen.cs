﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Progra_analisis
{
    public partial class loadingScreen : Form
    {
        public loadingScreen()
        {
            InitializeComponent();
        }

        public void setPicture(Bitmap bmImage)
        {
            this.actualPicture.Image = bmImage;
        }

        private void loadingScreen_Load(object sender, EventArgs e)
        {

        }
    }
}