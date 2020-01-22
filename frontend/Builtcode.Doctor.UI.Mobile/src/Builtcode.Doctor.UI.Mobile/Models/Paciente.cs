using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using MvvmHelpers;
using SQLite;

namespace Builtcode.Doctor.UI.Mobile.Models
{
    [Table("Paciente")]
    public class Paciente  : ObservableObject
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Data_Nascimento { get; set; }
        
    }
}