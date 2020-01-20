using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using MvvmHelpers;

namespace Builtcode.Doctor.UI.Mobile.Models
{
    public class Medico  : ObservableObject
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string CRM_UF { get; set; }
    }
}