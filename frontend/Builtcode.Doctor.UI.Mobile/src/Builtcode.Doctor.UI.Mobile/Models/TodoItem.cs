using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using MvvmHelpers;

namespace Builtcode.Doctor.UI.Mobile.Models
{
    public class TodoItem : ObservableObject
    {
        public string Name { get; set; }

        public bool Done { get; set; }
    }
}