using  System;

namespace Builtcode.Doctor.Domain
{
    public class Paciente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Data_Nascimento { get; set; }
        
    }
}