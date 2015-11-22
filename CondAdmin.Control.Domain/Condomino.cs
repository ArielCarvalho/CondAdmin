using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondAdmin.Control.Domain
{
    class Condomino
    {
        public enum residenceType
        {
            apartment,
            house,
            other            
        }

        //Estou usando resident para o condômino, mas talvez a gente tenha que mudar, porque o dono não necessariamente reside, tenho que trocar o nome da classe tb, que ficou em português xD
        //Não sei se vale a pena usarmos o cpf e tal, vou deixar sem.
        //Queria discutir se deveriamos colocar uma lista com os Ids dos quem moram também e outra pra inqulino

        public int residentId { get; set; }
        public string residentName { get; set; }
        public residenceType resType { get; set; }
        public int residenceNum { get; set; }
        public bool isTennant { get; set; } /*True se for inquilino, false se for dono.*/
        public bool isMainResident { get; set; } /*True se for o principal, false se for dependente. Inquilino também pode ser principal ou dependente.*/
    }
}
