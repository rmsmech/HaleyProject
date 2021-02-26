﻿using Haley.Abstractions;
using Haley.Enums;
using Haley.Events;
using Haley.Models;
using Haley.MVVM;
using Haley.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Test
{
    public class GlobalData :ChangeNotifier
    {
        private Theme _current_theme;
        public Theme current_theme
        {
            get { return _current_theme; }
            set { SetProp(ref _current_theme, value); }
        }

        public static GlobalData Singleton = new GlobalData();
        public static GlobalData getSingleton()
        {
            if (Singleton == null) Singleton = new GlobalData();
            return Singleton;
        }

        public static void Clear()
        {
            Singleton = new GlobalData();
        }
        private GlobalData() { current_theme = new Theme() { }; }

    }
}
