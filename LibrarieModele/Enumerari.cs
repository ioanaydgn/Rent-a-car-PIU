using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public enum ModelMasina 
    {
        Opel = 1,
        Renault = 2,
        BMW = 3,
        Audi = 4,
        Dacia = 5,
        Ford = 6,
        Volkswagen = 7,
        Mercedes = 8,
        Tesla = 9
    };

    [Flags]
    public enum OptiuniMasina
    {
        niciuna = 0,
        aer_conditionat = 1,
        navigatie = 2,
        cutie_automata = 4,
        geamuri_electrice = 8,
        decapotabila = 16
    };
    

}
