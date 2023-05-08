using AdoNet.Constans;
using System.Data;
using System.Data.SqlClient;


menu:
Console.WriteLine("Pizzalari ekrana cixarmaq isteyirsense 1 / Yeni pizza yaratmaq isteyirsense 2 i daxil edin:");
int cavab = int.Parse(Console.ReadLine());
if (cavab == 1)
{
    Console.WriteLine("-----------------------------");
    GetAllPizza();
    Console.WriteLine("pizza haqqinda etrafli melumat almaq isteyirsense id-sini,istemirsizse 0 daxil edin");
    int cvb = int.Parse(Console.ReadLine());
    if (cvb == 0)
    {
        goto menu;
    }
    else
    {
        Console.WriteLine("------------------------------");
        GetAllPizzaIngredient(cvb);
    }

}
else if (cavab == 2)
{
    Console.WriteLine("Pizzanin adini daxil edin.");
    string Pizzaname = Console.ReadLine();
choose:
    Console.WriteLine("Pizzanin Innergredientini secin");
    GetAllInnergredients();
    int Innergredientnum = int.Parse(Console.ReadLine());

    if (Innergredientnum == 0)
    {
        Console.WriteLine("zehmet olmasa birini secin");
        goto choose;
    }
    Console.WriteLine("-------------------------------------");
    Console.WriteLine(Ingredientnum(Innergredientnum));
    Console.WriteLine("-------------------------------------");

    string Innergredientname = Ingredientnum(Innergredientnum);
size:
    Console.WriteLine("Pizzanin olcusunu secin");
    GetAllSizes();
    int Sizenum = int.Parse(Console.ReadLine());
    if (Sizenum == 0)
    {
        Console.WriteLine("zehmet olmasa birini secin");
        goto size;
    }
    Console.WriteLine("-------------------------------------");
    Console.WriteLine(Sizesnum(Sizenum));
    Console.WriteLine("-------------------------------------");
    string Sizename = Sizesnum(Sizenum);
    //Insert(Innergredientname);
    Console.WriteLine("Pizzanin qiymetini daxil edin.");
    int Price = int.Parse(Console.ReadLine());

}

void GetAllSizes()
{
    using (SqlConnection conn = new SqlConnection(Urls.connectionstring))
    {
        conn.Open();
        string commandtext = "select * from Sizes";
        using (SqlCommand cmd = new SqlCommand(commandtext, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetInt32(0)} . {reader.GetString(1)} ");
                    }
                }
                else
                {
                    Console.WriteLine("Table is empty");
                }
            }

        }

    }

}

string Sizesnum(int id)
{
    using (SqlConnection conn = new SqlConnection(Urls.connectionstring))
    {
        conn.Open();
        string commandtext = "select * from Sizes where  Id=@id";
        using (SqlCommand cmd = new SqlCommand(commandtext, conn))
        {
            cmd.Parameters.AddWithValue("id", SqlDbType.Int).Value = id;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string Sizename = ($"  {reader.GetString(1)} ");
                        return Sizename;
                    }
                }
                else
                {
                    Console.WriteLine("Table is empty");
                }
            }

        }

    }
    return null;

}


string Ingredientnum(int id)
{
    using (SqlConnection conn = new SqlConnection(Urls.connectionstring))
    {
        conn.Open();
        string commandtext = "select * from Innergredients where  Id=@id";
        using (SqlCommand cmd = new SqlCommand(commandtext, conn))
        {
            cmd.Parameters.AddWithValue("id", SqlDbType.Int).Value = id;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string Inname = ($"  {reader.GetString(1)} ");
                        return Inname;
                    }
                }
                else
                {
                    Console.WriteLine("Table is empty");
                }
            }

        }

    }
    return null;

}
void GetAllInnergredients()
{
    using (SqlConnection conn = new SqlConnection(Urls.connectionstring))
    {
        conn.Open();
        string commandtext = "select * from Innergredients";
        using (SqlCommand cmd = new SqlCommand(commandtext, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetInt32(0)} . {reader.GetString(1)} ");
                    }
                }
                else
                {
                    Console.WriteLine("Table is empty");
                }
            }

        }

    }

}


void GetAllPizza()
{
    using (SqlConnection conn = new SqlConnection(Urls.connectionstring))
    {
        conn.Open();
        string commandtext = "select * from GetUpdateView";
        using (SqlCommand cmd = new SqlCommand(commandtext, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetInt32(0)}  {reader.GetString(1)}  {reader.GetString(2)}  {reader.GetInt32(3)}");
                    }
                }
                else
                {
                    Console.WriteLine("Table is empty");
                }
            }

        }

    }

}




void GetAllPizzaIngredient(int id)
{
    using (SqlConnection conn = new SqlConnection(Urls.connectionstring))
    {
        conn.Open();
        string commandtext = "select * from GetPizzaInnergradients where  GetPizzaInnergradients.[Pizzanin Id]=@id";
        using (SqlCommand cmd = new SqlCommand(commandtext, conn))
        {
            cmd.Parameters.AddWithValue("id", SqlDbType.Int).Value = id;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetInt32(0)}  {reader.GetString(1)}  {reader.GetString(2)}  {reader.GetString(3)}  {reader.GetInt32(4)} {reader.GetString(5)}");
                    }
                }
                else
                {
                    Console.WriteLine("Table is empty");
                }
            }

        }

    }

}









async void Insert(string name)
{
    using (SqlConnection conn = new SqlConnection(Urls.connectionstring))
    {
        conn.Open();
        string commandtext = "insert into numune values(@name)";
        using (SqlCommand cmd = new SqlCommand(commandtext, conn))
        {
            SqlParameter[] param =
            {
                CreateSqlParametr("name",SqlDbType.NVarChar,name)
            };
            cmd.Parameters.AddRange(param);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Ok");
            }
            else
            {
                Console.WriteLine("Not okey");
            }
        }

    }

}



SqlParameter CreateSqlParametr(string name, SqlDbType sqlDbType, object newobj)
{
    SqlParameter sqlParameter = new SqlParameter(name, sqlDbType);
    sqlParameter.Value = newobj;
    return sqlParameter;
}