﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Haley.Flipper.MVVM.Interfaces;

namespace DevelopmentWPF.Controls
{
    /// <summary>
    /// Interaction logic for ctrl01.xaml
    /// </summary>
    public partial class ctrl01 : UserControl, IFlipperControl
    {
        public ctrl01()
        {
            InitializeComponent();
        }
    }
}