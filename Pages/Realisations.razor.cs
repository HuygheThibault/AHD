using AHD.Models;
using Microsoft.AspNetCore.Components;

namespace AHD.Pages
{
    public partial class Realisations
    {
        static string img = "https://www.dakwerken-adviseur.be/wp-content/uploads/2017/10/dakwerken-1.jpg";
        private List<Realisation> RealisationsList = new List<Realisation>
        {
            new Realisation(1, "Test", "Test description", img, [img]),
            new Realisation(2, "Test", "Test description", img, [img]),
            new Realisation(3, "Test", "Test description", img, [img]),
            new Realisation(4, "Test", "Test description", img, [img]),
            new Realisation(5, "Test", "Test description", img, [img])
        };

       
    }
}
