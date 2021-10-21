using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafiskMiniräknare
{
    public partial class KalkyLator : Form
    {   //Dessa är värden är tillgänglig för objekt som skapas från klassen Kalkylator
        private bool key = false, ClearAllkey2 = false, repeatkey = false, DivWithZero = false;
        private string ButtonRef = "", ButtonForEquate = "";
        private Double Result = 0, NewResult = 0, CurrentValue = 0;
        private string LabelTextResult = "";
        public KalkyLator() //En funktion som har uppgift att bl.a. ge textboxen värdet 0 
        {
            InitializeComponent(); // En metod som innehåller koden för att automatisk skapa och ändra formuläret (Användargränsnittsobjekt).
            textBox1.Text = "0";

        }

        private void Button_Click(object sender, EventArgs e) //En funktion som håller koll på vad användaren har klickat för knapp.
        {
            kontroll(); //Kontrollfunktion. Scrolla här ner för att se implementeringskoden.
            Button button = (Button)sender; //sender referar till objektet som åberopade händelsen. Skapar ett objekt av sammma knappklass som typkastar avsändaren (knappen). 
            //Användbart om man har många objekt som använder samma händelseshanterar
            textBox1.Text += button.Text; //De som användaren klickar på sparas i textboxen, vilket är numeriska värden 0-9.
            CurrentValue = Double.Parse(textBox1.Text); //Nuvarande värde

        }

        private void ButtonForDecimal_Click(object sender, EventArgs e) // En funcktion som hanterar decimaltecken samt förhindrar uppreningar av decimaltecken.
        {
            if (!textBox1.Text.Contains(","))
            {
                textBox1.Text = textBox1.Text + ",";
            }

        }

        private void ButtonorOperator_Click(object sender, EventArgs e)
        {
            kontroll(); //Kontrollfunktion
            Button btn = (Button)sender;
            ButtonRef = btn.Text; //Hämtar texten som användaren har klickat på, vilket är -,+,/ eller *
            if (ButtonForEquate != "=") //Denna if-sats används för att kontrollera om likamedtecken har klickats innan. 
            {
                switch (ButtonRef) //switch-sats
                {
                    case "+":

                        if (String.IsNullOrEmpty(label1.Text)) //Är sant om labelns text är null eller en tom sträng ("").
                        {
                            if (string.Compare(textBox1.Text, "") == 0) //Denna if-sats är sant om användaren klickar på "+"-knappen direkt när programmet startar.
                            {
                                label1.Text = "0" + btn.Text;
                                textBox1.Text = "0";
                            }
                            else //Annars sparas värdet + operatorn (+) i labeln
                            {
                                label1.Text = textBox1.Text + btn.Text;

                            }
                        }
                        break;

                    case "-":
                        if (String.IsNullOrEmpty(label1.Text))
                        {
                            if (string.Compare(textBox1.Text, "") == 0)
                            {
                                label1.Text = "0" + btn.Text;
                                textBox1.Text = "0";
                            }
                            else //Sparas värdet + operatorn (-) i labeln
                            {

                                    label1.Text = textBox1.Text + btn.Text;
                                
                              
                            }
                        }
                        break;
                    case "*":
                        if (String.IsNullOrEmpty(label1.Text))
                        {
                            if (string.Compare(textBox1.Text, "") == 0)
                            {
                                label1.Text = "0" + btn.Text;
                                textBox1.Text = "0";
                            }
                            else //Sparar värdet + operatorn (*) i labeln
                            {
                                label1.Text = textBox1.Text + btn.Text;
                            }
                        }
                        break;
                    case "/":
                        if (String.IsNullOrEmpty(label1.Text))
                        {
                            if (string.Compare(textBox1.Text, "") == 0)
                            {
                                label1.Text = "0" + btn.Text;
                                textBox1.Text = "0";
                            }
                            else //Sparar värdet + operatorn (/) i labeln
                            {
                                label1.Text = textBox1.Text + btn.Text;
                            }
                        }
                        break;
                }

            }
            else
            { //Kommer in hit när användaren har t.ex adderat två tal och sedan klickat på en av artimetiska operatorerna "+,-,*,/"
                textBox1.Text = Result.ToString();
                label1.Text = Result.ToString() + btn.Text;
                repeatkey = false; //Denna variabel används i repeatfunktionen och kontrollerar om ett tal ska ändras under ett antal upprepningar med samma värde


            }
            key = true;  //Används för att textboxen ska kunna rensa när användaren lägger till ett annat värde 

        }

        private void ButtonForEqually(object sender, EventArgs e)
        {
            if (label1.Text.Length > 1) //Denna if-sats ser till att den artimetiska operator tas bort när programmet gör beräkningar.
            {
                LabelTextResult = label1.Text.Remove(label1.Text.Length - 1);
            }

            if (ButtonForEquate != "=") //Har användaren klickat på knappen för likamedtecken innan?
            {
                switch (ButtonRef)
                {
                    case "+":
                        if (string.Compare(textBox1.Text, "") != 0) //Kontrollerar om användaren har anget ett värde i textboxen.
                        {
                            Result = Double.Parse(LabelTextResult) + Double.Parse(textBox1.Text); //Resultatet av två värden som adderas.
                            label1.Text = LabelTextResult + "+" + textBox1.Text + "="; //Dem två värden visas i labeln.
                            textBox1.Text = Result.ToString(); //Resultatet visas i textboxen. 

                        }

                        break;
                    case "-":
                        if (string.Compare(textBox1.Text, "") != 0)
                        { 
                            Result = Double.Parse(LabelTextResult) - Double.Parse(textBox1.Text); //Resultatet av två värden som subtraheras.
                            label1.Text = LabelTextResult + "-" + textBox1.Text + "=";
                            textBox1.Text = Result.ToString();
                        }
                        break;
                    case "*":
                        if (string.Compare(textBox1.Text, "") != 0)
                        {
                            Result = Double.Parse(LabelTextResult) * Double.Parse(textBox1.Text); //Resultatet av två värden som multipliceras.
                            label1.Text = LabelTextResult + "*" + textBox1.Text + "=";
                            textBox1.Text = Result.ToString();

                        }
                        break;
                    case "/":
                        if (string.Compare(textBox1.Text, "") != 0)
                        {
                            if (string.Compare(textBox1.Text, "0") == 0)
                            {
                                if (LabelTextResult == "0") //Kommer in hit när värdet i textboxen och labeln är lika med 0.
                                {
                                    textBox1.Text = "Odefinierat resultat‬";
                                    label1.Text = LabelTextResult + "/";
                                    DivWithZero = true;  //Denna boolean variabel används för att inte texten "Odefinierat resultat‬" sparas i labeln. se rad 196.
                                }
                                else //Detta sker när användaren försöker dela ett värde med 0 
                                {
                                    label1.Text = LabelTextResult + "/";
                                    textBox1.Text = "Det går inte att dela med 0";
                                    key = true;
                                    DivWithZero = true;  //Denna boolean variabel används för att inte texten "Det går inte att dela med 0‬" sparas i labeln. se rad 196.
                                }
                            }
                            else //Programmet kommer in hit om textboxen inte är lika med 0
                            {
                                Result = Double.Parse(LabelTextResult) / Double.Parse(textBox1.Text); //Resultatet av två värden som divideras.
                                label1.Text = LabelTextResult + "/" + textBox1.Text + "=";
                                textBox1.Text = Result.ToString();
                            }
                        }

                        break;
                }
            }
            else
            {
                repeatfunction(); //Anropar på funktionen när användaren har redan klickat på knappen för likamedstecken. Funktionen hanterar vad som sker när--->
                //---->vid upprepade tryck på ’=’.

            }

            if (Result == 0) //Denn if-sats är sant när användaren klickar på "="-knappen direkt när programmet startar.
            {
                if (DivWithZero) //Om boolean variabeln är sant då ska labelns värde vara ""
                {
                    label1.Text = "";
                }
                else //Annars sätts värdet in i labeln. 
                {
                    label1.Text = textBox1.Text + " " + "=";
                }

                key = true; //Används för att textboxen ska kunna rensa när användaren lägger till ett nytt värde 
            }
            ButtonForEquate = (sender as Button).Text;  //Kastar avsändarobjektet till knappen d.v.s. ta reda på vilken knapp som har klickats. 
            repeatkey = true; //Används i repeatfunktionen.
            key = true;
            ClearAllkey2 = true;

        }

        private void ClearTextField_Click(object sender, EventArgs e) //Denna metod rensar texten i textboxen, men om användaren har redan klickat på "="-knappen då rensas allt
        {
            textBox1.Text = "0";
            if (label1.Text.Length == 0)
            {
                Result = 0;
            }

            if (ButtonForEquate == "=")
            {
                label1.Text = "";
                LabelTextResult = CurrentValue.ToString();
                Result = 0;
                NewResult = 0;
                CurrentValue = 0;
                DivWithZero = false;
                ButtonForEquate = "null";
            }
            key = true;
        }

        private void ClearEverything_Click(object sender, EventArgs e) //Denna metod rensar allt
        {

            textBox1.Text = "0";
            label1.Text = "";
            Result = 0;
            NewResult = 0;
            CurrentValue = 0;
            DivWithZero = false;
            key = true;

        }

        private void kontroll() //Kontroll för hur programmet ska bete sig i olika moment 
        {

            if (key) //Denna if-sats ser till att textboxen rensas 
            {
                if (string.Compare(label1.Text, "") != 0 || DivWithZero)
                {
                    textBox1.Text = "";
                    key = false;
                }
            }


            if (textBox1.Text == "0") //Denna if-sats ändrar textboxen värde från 0 till ingenting ""; 
            {
                textBox1.Text = "";
            }


            if (ClearAllkey2)
            {
                label1.Text = "";
                ClearAllkey2 = false;

            }
            if (Result == 0 && ButtonForEquate == "=")
            {
                label1.Text = "";
                key = false;
            }
            if (ButtonForEquate == "=" && textBox1.Text.Length >= 1)
            {
                Result = double.Parse(textBox1.Text);
                ButtonForEquate = "null";
            }


        }

        private void repeatfunction() //Funktionen anropas vid upprepade tryck på ’=’.
        {
            switch (ButtonRef)
            {
                case "+":
                    if (string.Compare(textBox1.Text, "") != 0 && repeatkey)    //T.ex om användaren hade adderat två tal (5+5=10) och tryckt på =knappen två gånger då hade resultatet bli 15
                    {                                                           //-> Och om användaren fortsätter klicka på "="-knappen då ökar värdet med 5 varje gång.->
                        NewResult = CurrentValue + Result;
                        label1.Text = textBox1.Text + "+" + CurrentValue + "=";
                        textBox1.Text = NewResult.ToString();
                        Result = Double.Parse(textBox1.Text);
                    }
                    else                                                       //->Men om användaren hade tryckt på "+"-knappen efter ett antal upprepningar då hade det nya resultatet bli de som finnns i textboxen.
                    {                                                          //-> men  om användaren hade anget ett värde därefter och  tryckt "="-knappen, då hade det nya värdet öka med de som finns i texboxen
                                                                               //-> Alltså currentValue. Variabeln repeatkey kontrollerar om det värdet ska upprepas eller om det handlar om ett nytt värde 
                        CurrentValue = Double.Parse(textBox1.Text);
                        label1.Text = Result + "+" + CurrentValue + "=";
                        NewResult = Result + CurrentValue;
                        textBox1.Text = NewResult.ToString();
                        Result = Double.Parse(textBox1.Text);

                    }
                    break;
                case "-":
                    if (string.Compare(textBox1.Text, "") != 0 && repeatkey)
                    {
                        NewResult = Result - CurrentValue;
                        label1.Text = textBox1.Text + "-" + CurrentValue + "=";
                        textBox1.Text = NewResult.ToString();
                        Result = Double.Parse(textBox1.Text);
                    }
                    else
                    {

                        CurrentValue = Double.Parse(textBox1.Text);
                        label1.Text = Result + "-" + CurrentValue + "=";
                        NewResult = Result - CurrentValue;
                        textBox1.Text = NewResult.ToString();
                        Result = Double.Parse(textBox1.Text);
                    }
                    break;
                case "*":
                    if (string.Compare(textBox1.Text, "") != 0 && repeatkey)
                    {
                        NewResult = Result * CurrentValue;
                        label1.Text = textBox1.Text + "*" + CurrentValue + "=";
                        textBox1.Text = NewResult.ToString();
                        Result = Double.Parse(textBox1.Text);

                    }
                    else
                    {
                        CurrentValue = Double.Parse(textBox1.Text);
                        label1.Text = Result + "*" + CurrentValue + "=";
                        NewResult = Result * CurrentValue;
                        textBox1.Text = NewResult.ToString();
                        Result = Double.Parse(textBox1.Text);
                    }
                    break;
                case "/":
                    if (String.Compare(textBox1.Text, "Det går inte att dela med 0") == 0)
                    {
                        textBox1.Text = "0";
                        label1.Text = "";
                    }
                    if (string.Compare(textBox1.Text, "") != 0 && repeatkey)
                    {
                        if (CurrentValue > 0)
                        {
                            NewResult = Result / CurrentValue;
                            label1.Text = textBox1.Text + "/" + CurrentValue + "=";
                            textBox1.Text = NewResult.ToString();
                            Result = Double.Parse(textBox1.Text);
                        }
                        else
                        {
                            textBox1.Text = "0";
                            label1.Text = "";
                        }

                    }
                    else
                    {
                        if (CurrentValue > 0)
                        {
                            CurrentValue = Double.Parse(textBox1.Text);
                            label1.Text = Result + "/" + CurrentValue + "=";
                            NewResult = Result / CurrentValue;
                            textBox1.Text = NewResult.ToString();
                            Result = Double.Parse(textBox1.Text);
                        }
                        else
                        {
                            textBox1.Text = "0";
                            label1.Text = "";
                        }

                    }
                    break;
            }


        }

    }
}