using ROCvanTwente.Sumpel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROCvanTwente.Sumpel.Semester1.Galgje
{
    public class RandomWord
    {
        private static readonly string[] WORDS =
        {
"XYLOFOON",
"HERFSTSTORM",
"CAVIA",
"KRUKJE",
"SAMBAL",
"ZUIVEL",
"KRITISCH",
"JASJE",
"DIEREN",
"LEPEL",
"PICKNICK",
"QUASI",
"VERZENDEN",
"WINNAAR",
"DEXTROSE",
"VREZEN",
"NIQAAB",
"HIERBIJ",
"QUOTE",
"BOTOX",
"CRUCIAAL",
"ZITTING",
"CABARET",
"BEWOGEN",
"VRIJUIT",
"CARRIÈRE",
"IJVERIG",
"DYSLEXIE",
"NIHIL",
"SAUSJE",
"KUUROORD",
"POPPETJE",
"DOCENT",
"CAMPING",
"SCHIJN",
"KLOPPEN",
"DETOX",
"BOYCOT",
"CYCLUS",
"CENSUUR",
"AAIBAAR",
"CHAGRIJNIG",
"FICTIEF",
"GERING",
"NACHT",
"CACAO",
"TRIOMF",
"IJSTIJD",
"CRUISEN",
"ONTZEGGEN",
"TURQUOISE",
"CARNAVAL",
"BOXER",
"STRAKS",
"FYSIEK",
"TWIJG",
"QUOTE",
"GAMMEL",
"FLIRT",
"FUTLOOS",
"VREUGDE",
"GELOOF",
"PERIODE",
"VOLWAARDIG",
"UITLEG",
"STIJL",
"ALLIANTIE",
"TOCHT",
"JOGGEN",
"BROEK",
"WERKSFEER",
"NIEUW",
"SOPRAAN",
"MILJOEN",
"INRICHTING",
"KLACHT",
"SCHIKKING",
"PRINT",
"OORLOG",
"ZIJRAAM",
"HYACINT",
"FNUIKEND",
"POLDER",
"UITZWAAIEN",
"PROGRAMMEREN",
"UITZOEKEN",
"OVERWAAIEN"
        };

        public static string getRandomWord()
        {
            return WORDS[LehmerRNG.Next(WORDS.Length)];
        }
    }
}
