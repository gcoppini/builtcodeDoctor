using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using MvvmHelpers;
using SQLite;

namespace Builtcode.Doctor.UI.Mobile.Models
{
    [Table("Medico")]
    public class Medico  : ObservableObject
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string CRM_UF { get; set; }
    }
}