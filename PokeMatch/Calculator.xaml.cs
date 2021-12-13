using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static PokeMatch.MainPage;

namespace PokeMatch
{
    public partial class Calculator : ContentPage
    {
        List<string> FourTimesList = new List<string>();
        List<string> TwoTimesList = new List<string>();
        List<string> OneTimesList = new List<string>();
        List<string> HalfTimesList = new List<string>();
        List<string> QuarterTimesList = new List<string>();
        List<string> ZeroTimesList = new List<string>();


        public Calculator(PokeType t1, PokeType t2)
        {
            InitializeComponent();
            PlaceEffectness(t1, t2);
        }

        void PlaceEffectness(PokeType t1, PokeType t2)
        {
            foreach (var t in Enum.GetNames(typeof(PokeType)))
            {
                var index = 1f;
                if (t == "None")
                    continue;
                index *= CheckEffectiveness(t, t1.ToString());
                if (t2 != PokeType.None)
                    index *= CheckEffectiveness(t, t2.ToString());
                AddToList(t, index);
            }

            DisplayEffectiveness();
        }

        public void AddToList(string t, float index)
        {
            switch (index)
            {
                case 0f:
                    ZeroTimesList.Add(t);
                    break;
                case 0.25f:
                    QuarterTimesList.Add(t);
                    break;
                case 0.5f:
                    HalfTimesList.Add(t);
                    break;
                case 1f:
                    OneTimesList.Add(t);
                    break;
                case 2f:
                    TwoTimesList.Add(t);
                    break;
                case 4f:
                    FourTimesList.Add(t);
                    break;
                default:
                    throw new ArgumentException($"Index calculation was off. Index: {index}");
            }
        }

        float CheckEffectiveness(string questionType, string pokemonType)
        {
            if (SuperEffectiveDict[questionType].Contains(pokemonType))
            {
                return 2f;
            }
            else if (HalfEffectiveDict[questionType].Contains(pokemonType))
            {
                return 0.5f;
            }
            else if (NonEffectiveDict[questionType].Contains(pokemonType))
            {
                return 0f;
            }

            return 1;
        }

        void DisplayEffectiveness ()
        {
            FourTimeLabel.Text = PrintList (FourTimesList);
            TwoTimeLabel.Text = PrintList(TwoTimesList);
            OneTimeLabel.Text = PrintList(OneTimesList);
            HalfTimeLabel.Text = PrintList(HalfTimesList);
            QuarterTimeLabel.Text = PrintList(QuarterTimesList);
            ZeroTimeLabel.Text = PrintList(ZeroTimesList);
        }

        string PrintList(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var s in list)
            {
                if (string.IsNullOrEmpty(sb.ToString()))
                    sb.Append($" {s}");
                else
                    sb.Append($", {s}");
            }
            if (string.IsNullOrEmpty (sb.ToString()))
                sb.Append("None!");
            return sb.ToString();
        }

        static Dictionary<string, List<string>> SuperEffectiveDict = new Dictionary<string, List<string>>() {
            { "Normal", new List<string> () { } },
            { "Fighting", new List<string> () {"Normal", "Rock", "Steel", "Ice", "Dark" } },
            { "Flying", new List<string> () {"Fighting", "Bug", "Grass", } },
            { "Poison", new List<string> () {"Grass", "Fairy" } },
            { "Ground", new List<string> () {"Poison", "Rock", "Steel", "Fire", "Electric" } },
            { "Rock", new List<string> () {"Flying", "Bug", "Ice" } },
            { "Bug", new List<string> () {"Grass", "Psychic", "Dark" } },
            { "Ghost", new List<string> () {"Ghost", "Psychic" } },
            { "Steel", new List<string> () {"Rock", "Ice", "Fairy" } },
            { "Fire", new List<string> () {"Bug", "Steel", "Grass", "Ice" } },
            { "Water", new List<string> () {"Ground", "Rock", "Fire" } },
            { "Grass", new List<string> () {"Ground", "Rock", "Water" } },
            { "Electric", new List<string> () {"Flying", "Water" } },
            { "Psychic", new List<string> () {"Fighting", "Poison" } },
            { "Ice", new List<string> () {"Flying", "Ground", "Grass", "Dragon" } },
            { "Dragon", new List<string> () {"Dragon" } },
            { "Dark", new List<string> () {"Ghost", "Psychic" } },
            { "Fairy", new List<string> () {"Fighting", "Dragon", "Dark" } },
        };

        static Dictionary<string, List<string>> HalfEffectiveDict = new Dictionary<string, List<string>>() {
            { "Normal", new List<string> () {"Rock", "Steel" } },
            { "Fighting", new List<string> () {"Flying", "Poison", "Bug", "Psychic", "Fairy" } },
            { "Flying", new List<string> () {"Rock", "Electric" } },
            { "Poison", new List<string> () {"Poison", "Ground", "Rock", "Ghost" } },
            { "Ground", new List<string> () {"Bug", "Grass" } },
            { "Rock", new List<string> () {"Fighting", "Ground", "Steel" } },
            { "Bug", new List<string> () {"Fighting", "Flying", "Poison", "Ghost", "Steel", "Fire", "Fairy" } },
            { "Ghost", new List<string> () {"Dark" } },
            { "Steel", new List<string> () {"Steel", "Fire", "Water", "Electric" } },
            { "Fire", new List<string> () {"Fire", "Rock", "Water", "Dragon" } },
            { "Water", new List<string> () {"Water", "Grass", "Dragon" } },
            { "Grass", new List<string> () {"Flying", "Poison", "Bug", "Steel", "Fire", "Grass", "Dragon" } },
            { "Electric", new List<string> () {"Grass", "Electric", "Dragon" } },
            { "Psychic", new List<string> () {"Psychic", "Steel" } },
            { "Ice", new List<string> () {"Steel", "Fire", "Water", "Ice" } },
            { "Dragon", new List<string> () {"Steel" } },
            { "Dark", new List<string> () {"Fighting", "Dark", "Fairy" } },
            { "Fairy", new List<string> () {"Poison", "Steel", "Fire" } },
        };

        static Dictionary<string, List<string>> NonEffectiveDict = new Dictionary<string, List<string>>() {
            { "Normal", new List<string> () {"Ghost" } },
            { "Fighting", new List<string> () {"Ghost" } },
            { "Flying", new List<string> () {"" } },
            { "Poison", new List<string> () {"Steel" } },
            { "Ground", new List<string> () {"Flying" } },
            { "Rock", new List<string> () {"" } },
            { "Bug", new List<string> () {"" } },
            { "Ghost", new List<string> () {"Normal" } },
            { "Steel", new List<string> () {"" } },
            { "Fire", new List<string> () {"" } },
            { "Water", new List<string> () {"" } },
            { "Grass", new List<string> () {"" } },
            { "Electric", new List<string> () {"Ground" } },
            { "Psychic", new List<string> () {"Dark" } },
            { "Ice", new List<string> () {"" } },
            { "Dragon", new List<string> () {"Fairy " } },
            { "Dark", new List<string> () {"" } },
            { "Fairy", new List<string> () {"" } },
        };
    }

}
