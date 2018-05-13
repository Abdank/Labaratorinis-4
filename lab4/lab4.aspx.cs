using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class lab4 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        List<Book> books = Reading();
        Actions(books);
        
    }
    /// <summary>
    /// Atlieka veiksmus
    /// </summary>
    /// <param name="a"> Knygų sąrašas</param>
    void Actions (List<Book> a)
    {

        List<Book> filtered = SortByCriteria(a);
        filtered.Sort();
        Delete(filtered);
        PrintList(Table1, filtered);
        PrintList(Table3, a);
        PrintTotxt(a, filtered);
        if (FileUpload1.HasFile)
        {
            PrintCriteria(Table2);
        }
        else
        {
            string path = Server.MapPath("App_Data/pirmas.txt");
        }
    }
    /// <summary>
    /// Ištrina knygas pagal ranka įvesta informaciją
    /// </summary>
    /// <param name="a"></param>
    void Delete(List<Book> a)
    {
        if (TextBox1.Text == "")
            return;
           
        for (int i = 0; i < a.Count; i++)
        {
                if (a[i].Years == int.Parse(TextBox1.Text))
                {
                    a.RemoveAt(i--);
                }

        }
    }
    /// <summary>
    /// Atspausdina atrinkimo duomenis
    /// </summary>
    /// <param name="table"></param>
    void PrintCriteria(Table table)
    {
        if (FileUpload1.HasFile)
        {
            string stduoma = Server.MapPath("App_Data/pirmas.txt");
            FileUpload1.SaveAs(stduoma);
            string[] lines = File.ReadAllLines(stduoma);
            TableRow row = new TableRow();
            TableCell pavadinimas = new TableCell();
            pavadinimas.Text = lines[0];
            row.Cells.Add(pavadinimas);
            table.Rows.Add(row);
        }
        else
        {
            string stduoma = Server.MapPath("App_Data/pirmas.txt");
        }
    }
    /// <summary>
    /// Atspausdina duomenys ir rezultatus i failus
    /// </summary>
    /// <param name="data"></param>
    /// <param name="Results"></param>
    void PrintTotxt(List<Book> data, List<Book> Results)
    {
        string path = Server.MapPath("App_Data/Duomenys.txt");
        using (StreamWriter writer = new StreamWriter(path))
        {
            if (FileUpload1.HasFile)
            {
                string stduoma = Server.MapPath("App_Data/pirmas.txt");
                FileUpload1.SaveAs(stduoma);
                string[] lines = File.ReadAllLines(stduoma);
                string[] criteria = lines[0].Split(';');
                writer.WriteLine("Atrinkimo duomenys:");
                writer.WriteLine("Metu intevalas - {0}", criteria[0]);
                writer.WriteLine("Kainos limitas - {0}", criteria[1]);
            }
            else
            {
                path = Server.MapPath("App_Data/pirmas.txt");
            }
            writer.WriteLine();
            writer.WriteLine("Pradiniai duomenys");
            writer.WriteLine("{0,-20}{1,-15}{2,-7}{3,-6}{4,-5}{5,-5}", "Autorius", "Pavadinimas", "Metai", "Kaina", "Parduota", "Liko");
            foreach(Book book in data)
            {
                writer.WriteLine(book.ToString());
            }
        }
        path = Server.MapPath("App_Data/Rezultatai.txt");
        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.WriteLine();
            writer.WriteLine("Rezultatai");
            writer.WriteLine("{0,-20}{1,-15}{2,-7}{3,-6}{4,-5}{5,-5}", "Autorius", "Pavadinimas", "Metai", "Kaina", "Parduota", "Liko");
            foreach (Book book in Results)
            {
                writer.WriteLine(book.ToString());
            }
        }
    }
    /// <summary>
    /// Spausdina sąrašą
    /// </summary>
    /// <param name="table"></param>
    /// <param name="list"></param>
    void PrintList(Table table, List<Book> list)
    {
        TableText(table, "Autorius;Pavadinimas;Metai;Kaina;Parduota;Liko");
        foreach(Book book in list)
        {
            AddRow(book, table);
        }
    }
    /// <summary>
    /// Spausdina klaidą į lentelę
    /// </summary>
    /// <param name="a"></param>
    void PrintError(string a)
    {
        TableRow row = new TableRow();
        TableCell pavadinimas = new TableCell();
        pavadinimas.Text = a;
        row.Cells.Add(pavadinimas);
        Table4.Rows.Add(row);
    }
    /// <summary>
    /// Skaito knygas iš Duomenys katalogo
    /// </summary>
    /// <returns></returns>
    List<Book> Reading()
    {
        List<Book> a = new List<Book>();
        string hmm = Server.MapPath("Duomenys");

        try
        {
            var txtFiles = Directory.EnumerateFiles(hmm, "*.txt");
            foreach (string currentFile in txtFiles)
            {
                using (StreamReader reader = new StreamReader(currentFile))
                {
                    string Bookstore = reader.ReadLine();
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] data = line.Split(';');
                        a.Add(new Book(data[0], data[1], int.Parse(data[2]), double.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]), Bookstore));
                        line = reader.ReadLine();
                    }
                }

            }
        }
        catch (Exception ex)
        {
            PrintError(ex.Message);
        }
        return a;
    }


    /// <summary>
    /// Rūšiuoja pagal kriterijus
    /// </summary>
    /// <param name="books"></param>
    /// <returns></returns>
    List<Book> SortByCriteria(List<Book> books)
    {
        List<Book> a = new List<Book>();

        return books.FindAll(Criteria);
    }
    /// <summary>
    /// Nuskaito kriterijus
    /// </summary>
    /// <param name="years"></param>
    /// <param name="price"></param>
    /// <param name="path"></param>
    static void GetCriteria(out string[] years, out double price, string path)
    {
        using (StreamReader reader = new StreamReader(path))
        {
            string line = reader.ReadLine();
            string[] data = line.Split(';');
            years = data[0].Split('-');
            price = double.Parse(data[1]);
        }
    }
    /// <summary>
    /// Gauna atrinkimo duomenų kelią
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    bool GetPath(out string path)
    {
        path = "";
        bool a = false;
        if (FileUpload1.HasFile)
        {
            string stduoma = Server.MapPath("App_Data/pirmas.txt");
            FileUpload1.SaveAs(stduoma);
            path = stduoma;
            a = true;
        }
        else
        {
            path = Server.MapPath("App_Data/pirmas.txt");
        }
        return a;
    }
    /// <summary>
    /// kriterijus
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    bool Criteria(Book book)
    {
        string path;
        double price;
        string[] YearsString = new string[2];
        if (GetPath(out path))
        {
            GetCriteria(out YearsString, out price, path);
        }
        else
        {
            YearsString[0] = "1";
            YearsString[1] = "2100";
            price = 99999999;
        }
        int[] years = new int[2];
        years[0] = int.Parse(YearsString[0]);
        years[1] = int.Parse(YearsString[1]);


        if (book.Years >= years[0] && book.Years <= years[1] && book.Price <= price)
            return true;
        else
            return false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
    /// <summary>
    /// Metodas eilutes lentelėje pridejimui
    /// </summary>
    /// <param name="a"></param>
    /// <param name="lentele"></param>
    static void AddRow(Book a, Table lentele)
    {
        TableRow row = new TableRow();
        string[] data = a.ToTable().Split(';');
        for (int i = 0; i < 6; i++)
        {
            row.Cells.Add(cell(data[i]));
        }
        lentele.Rows.Add(row);

    }
    /// <summary>
    /// sukuriamas lenteles langelis
    /// </summary>
    /// <param name="tekstas"> langelio tekstas</param>
    /// <returns> grtažina langelį</returns>
    static TableCell cell(string tekstas)
    {
        TableCell cell = new TableCell();
        cell.Text = tekstas;
        return cell;
    }
    /// <summary>
    /// Sukuriama rezultatų lentelės antraštė
    /// </summary>
    /// <param name="lentele"> į kurią lentelę vesti</param>
    static void TableText(Table lentele, string a)
    {
        string[] datas = a.Split(';');
        TableRow Eilute = new TableRow();
        foreach (string data in datas )
        {
            Eilute.Cells.Add(cell(data));
        }
        //"Autorius,Pavadinimas,Metai,Kaina,Parduota,Liko";
        lentele.Rows.Add(Eilute);
    }


}