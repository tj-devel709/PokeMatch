using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

#nullable enable

namespace PokeMatch
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public PokeType SelectedType1 { get; set; } = PokeType.None;
        public PokeType SelectedType2 { get; set; } = PokeType.None;
        Button? selectedButton1 = null;
        Button? selectedButton2 = null;

        public enum PokeType
        {
            None,
            Grass,
            Rock,
            Ice,
            Dragon,
            Dark,
            Psychic,
            Bug,
            Flying,
            Steel,
            Fire,
            Fighting,
            Ground,
            Ghost,
            Poison,
            Water,
            Fairy,
            Electric,
            Normal,
        }

        void PressDownButton(Button b, PokeType t)
        {
            if (IsUnselectButton(b))
                return;

            if (SelectedType1 == PokeType.None)
            {
                SelectedType1 = t;
                selectedButton1 = b;
                SelectButton(selectedButton1);
                // debugging
                Label1.Text = t.ToString();
                return;
            }
            else if (SelectedType2 == PokeType.None)
            {
                SelectedType2 = t;
                selectedButton2 = b;
                SelectButton(selectedButton2);
                // debugging
                Label2.Text = t.ToString();
                return;
            }
            else
            {
                // unselect the old button
                UnSelectButton(selectedButton1);

                SelectedType1 = SelectedType2;
                selectedButton1 = selectedButton2;
                // debugging
                Label1.Text = SelectedType2.ToString();

                SelectedType2 = t;
                selectedButton2 = b;
                SelectButton(selectedButton2);
                // debugging
                Label2.Text = t.ToString();
            }
        }

        bool IsUnselectButton(Button b)
        {
            if (selectedButton1 == b)
            {
                UnSelectButton(b);
                SelectedType1 = SelectedType2;
                selectedButton1 = selectedButton2;
                // debugging
                Label1.Text = SelectedType1.ToString();

                SelectedType2 = PokeType.None;
                selectedButton2 = null;
                // debugging
                Label2.Text = "Type2";
                return true;
            }

            else if (selectedButton2 == b)
            {
                UnSelectButton(b);
                SelectedType2 = PokeType.None;
                selectedButton2 = null;
                // debugging
                Label2.Text = "Type2";
                return true;
            }
            return false;
        }

        void SelectButton (Button? b)
        {
            b!.Scale = 2.0;
        }

        void UnSelectButton (Button? b)
        {
            b!.Scale = 1;
        }



        void WaterButtonClicked (Object sender, EventArgs e)
        {
            Button clickedButton = (Button) sender;
            PressDownButton(clickedButton, PokeType.Water);
            clickedButton.Scale = 2;
        }

        void FireButtonClicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            PressDownButton(clickedButton, PokeType.Fire);
        }

        void GrassButtonClicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            PressDownButton(clickedButton, PokeType.Grass);
        }

        void RockButtonClicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            PressDownButton(clickedButton, PokeType.Rock);
        }

        void IceButtonClicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            PressDownButton(clickedButton, PokeType.Ice);
        }

        void DragonButtonClicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            PressDownButton(clickedButton, PokeType.Dragon);
        }

        void DarkButtonClicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            PressDownButton(clickedButton, PokeType.Dark);
        }

        void PsychicButtonClicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            PressDownButton(clickedButton, PokeType.Psychic);
        }

        void BugButtonClicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            PressDownButton(clickedButton, PokeType.Bug);
        }

        void FlyingButtonClicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            PressDownButton(clickedButton, PokeType.Flying);
        }

        void SteelButtonClicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            PressDownButton(clickedButton, PokeType.Steel);
        }

        void FightingButtonClicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            PressDownButton(clickedButton, PokeType.Fighting);
        }

        void GroundButtonClicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            PressDownButton(clickedButton, PokeType.Ground);
        }

        void GhostButtonClicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            PressDownButton(clickedButton, PokeType.Ghost);
        }

        void PoisonButtonClicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            PressDownButton(clickedButton, PokeType.Poison);
        }

        void FairyButtonClicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            PressDownButton(clickedButton, PokeType.Fairy);
        }

        void ElectricButtonClicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            PressDownButton(clickedButton, PokeType.Electric);
        }

        void NormalButtonClicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            PressDownButton(clickedButton, PokeType.Normal);
        }

        async void CalculateButtonClicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Calculator(SelectedType1, SelectedType2));
        }
    }
}
