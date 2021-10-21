using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottoprogram
{
    public partial class Lotto : Form
    {   //Dessa är värden är tillgänglig för objekt som skapas från klassen Lotto.
        private List<int> Lottorad = new List<int> { };
        private int[] box = new int[7];
        public static int MAX = 6;
        public int Tal, Dragningar = 0, rx;
        public Random random = new Random(); //Skapar ett random objekt för att kunna använda metoder som bl.a. Next();
        public string text = "";
        private TextBox focusedTextbox = null;
        public Lotto() //En funktion som innehåller koden för att automatisk skapa och ändra formuläret (Användargränsnittsobjekt). 
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e) //Vad som sker när man klickar på knappen "Starta Lotto".
        {
            //Nollställer resultatboxarna för att inte greja med gamla resultat.
            ResultBox5.Text = "";
            ResultBox6.Text = "";
            ResultBox7.Text = "";
            if (ValidationTextBox()) //En funktion som tar en del utav valideringsjobbet. Returnerar den sant då visas texten "Grattis" med färgen grönt.
            {
                FelInmatning.Text = "Grattis!";
                FelInmatning.Location = new Point(351, 106);
                FelInmatning.ForeColor = System.Drawing.Color.Green;
                for (int i = 0; i < Dragningar; i++) //Variabeln "dragningar" är antalet dragnignar användaren vill göra.
                {
                    DraLotto(); //Anropar på funktionen DraLotto.
                }

            }

        }

        public void DraLotto() //Funktionen är den som tar hand om resultatet. 
        {
            int[] box = new int[7];
            int r;

            for (int i = 0; i < box.Length; i++) //For-loopen gör 7 varv.
            {
                r = random.Next(1, 36); //Slumpar ett tal mellan 1 och 35.
                if (!box.Contains(r)) //Om det slumpade talet inte finns i listan, då lagras talet.
                {
                    box[i] = r;

                }
                else //Annars utför loopen ett till varv. 
                {
                    i--;
                }
            }

            for (int b = 0; b < box.Length; b++) //Dessa nästlade for-loopar kontrollerar hur många rätt användaren får.
            {
                for (int a = 0; a < Lottorad.Count; a++)
                {
                    if (box[b].Equals(Lottorad[a])) //Jämför alla värden som finns i både arrayen o listan. 
                    {                                 //Första värdet som finns i arrayen jämförs med alla värden i listan etc. 
                        rx++; //Om dessa värden är lika, öka variabeln med ett.
                    }
                }
            }

            int Resultat;
            if (rx == 5) //Om användaren får 5 rätt
            {
                if (ResultBox5.Text == "") //Första som sker. 
                {
                    Resultat = 0;
                    Resultat = Resultat + 1;
                    ResultBox5.Text = Resultat.ToString();
                }
                else //Om det blir mer än ett rätt 
                {
                    Resultat = int.Parse(ResultBox5.Text);
                    Resultat = Resultat + 1;
                    ResultBox5.Text = Resultat.ToString();
                }

            }

            if (rx == 6)  //Om användaren får 6 rätt
            {
                if (ResultBox6.Text == "")
                {
                    Resultat = 0;
                    Resultat = Resultat + 1;
                    ResultBox6.Text = Resultat.ToString();
                }
                else
                {
                    Resultat = int.Parse(ResultBox6.Text);
                    Resultat = Resultat + 1;
                    ResultBox6.Text = Resultat.ToString();
                }

            }
            if (rx == 7) //Om användaren får 7 rätt
            {
                if (ResultBox7.Text == "")
                {
                    Resultat = 0;
                    Resultat = Resultat + 1;
                    ResultBox7.Text = Resultat.ToString();
                }
                else
                {
                    Resultat = int.Parse(ResultBox7.Text);
                    Resultat = Resultat + 1;
                    ResultBox7.Text = Resultat.ToString();
                }

            }
            rx = 0; //Nollställer variabeln värde som lagrar antalet rätt.

        }

        public bool ValidationTextBox() //Funktionen för validering
        {
            if (Lottorad.Count == 7)  //Sant som användaren har anget ett värde för alla textboxar. 
            {
                foreach (int i in Lottorad) //Loopar igenom listan 
                {
                    if (i < 1 || 35 < i) //Om talet ligger utanför interavallet 1-35
                    {
                        FelInmatning.Text = "Ange endast tal mellan 1 till och med 35!";
                        FelInmatning.Location = new Point(240, 106);
                        FelInmatning.ForeColor = System.Drawing.Color.Red;
                        return false; //Returnerar false;
                    }
                }
            }
            else
            {
                FelInmatning.Text = "OBS! Ange värde för alla textboxar!";
                FelInmatning.Location = new Point(240, 106);
                FelInmatning.ForeColor = System.Drawing.Color.Red;
                return false;  //Returnerar false;
            }

            if (TextBoxForDraw.Text != "") //Om användaren har anget ett värde för antal dragningar, då går vi in i if-satsen.
            {
                try
                {
                    if (TextBoxForDraw.Text.Length < 8) //Max sjusiffrigt tal
                    {
                        Dragningar = Int32.Parse(TextBoxForDraw.Text); //Försöker Konverterar en sträng av ett nummer till ett 32-bitars heltal.
                    }
                    else
                    {
                        TextBoxForDraw.Text = "";
                        TextBoxForDraw.Focus();
                        MessageBox.Show("OBS! Max sjusiffrigt tal!");
                        return false;
                    }

                }
                catch (Exception) //Tar hand om eventuella fel. Exempelvis försöka konvertera en sträng av bokstäver. 
                {
                    FelInmatning.Text = "OBS! Antal dragingar ska endast vara i heltal!";
                    FelInmatning.Location = new Point(240, 106);
                    FelInmatning.ForeColor = System.Drawing.Color.Red;
                    TextBoxForDraw.Focus();
                    TextBoxForDraw.Text = "";
                    return false;//Returnerar false;
                }
            }
            else //Kommer in hit om användaren inte har anget ett värde för antal dragningar
            {
                FelInmatning.Text = "OBS! Ange antal dragningar!";
                FelInmatning.Location = new Point(240, 106);
                FelInmatning.ForeColor = System.Drawing.Color.Red;
                TextBoxForDraw.Focus();
                return false;//Returnerar false;
            }

            return true; //Qm allt går bra då returneras true;

        }

        private void TextBox_GetValues(object sender, EventArgs e) //Funktionen för att hämta värdet i en textbox.
        {
            if (focusedTextbox != null)
            {
                if (focusedTextbox.Text.Length == 10) //Är det mer än 10 tecken då rensas allt i textboxen.
                {
                    focusedTextbox.Text = "";
                }
                else //Annars lagrar vi värdet i string variabeln "text"
                {
                    //Variabeln "text" lagrar värdet som finns i den nuvarande textboxen. 
                    text = focusedTextbox.Text;
                }

            }

        }

        private void TextBox_Enter(object sender, EventArgs e) //Denna funktion ser till att gamla samt upprepande tal rensas från listan.
        {

            focusedTextbox = (TextBox)sender; //Ta reda på vilken textbox användaren är inne i.

            if (focusedTextbox.Text != "")
            {
                Tal = int.Parse(focusedTextbox.Text); //Variabeln "Tal" får värdet som finns i den nuvarande textboxen
                Lottorad.RemoveAll(check); //Metoden removeAll tar bort alla element som matchar villkoren som definieras i funktionen check.
                focusedTextbox.Text = ""; //Rensa textboxen.
            }

        }

        private bool check(int i) //Funktionen definierar villkoret.
        {
            return i == Tal;
        }

        private void TextBox_Leave(object sender, EventArgs e) //Funktionen kontrollerar så att användaren endast matar in unika tal samt siffror.
        {
            if (text != "")
            {
                try
                {
                    if (!Lottorad.Contains(int.Parse(text)))
                    { //Kontrollera om talet redan finns i listan. Returnerar true om det inte gör det.
                        Lottorad.Add(int.Parse(text)); //Lagrar värdet i listan
                        text = ""; //Nollställer variablens värde
                    }
                    else
                    {
                        MessageBox.Show("OBS! Ange unika tal!");
                        focusedTextbox.Text = "";
                        focusedTextbox.Focus();
                    }
                }
                catch (Exception) //Tar hand om eventuella fel som bl.a. användaren matar in bokstäver istället för siffror.
                {
                    MessageBox.Show("Ange endast siffror!");
                    focusedTextbox.Focus();
                    focusedTextbox.Text = "";

                }
            }

        }

    }
}
