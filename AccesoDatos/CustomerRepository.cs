using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CustomerRepository
    {
        public List<Customers> ObtenerTodo()
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String SelcetAll = "";
                SelcetAll = SelcetAll + "SELECT [CustomerID] " + "\n";
                SelcetAll = SelcetAll + "      ,[CompanyName] " + "\n";
                SelcetAll = SelcetAll + "      ,[ContactName] " + "\n";
                SelcetAll = SelcetAll + "      ,[ContactTitle] " + "\n";
                SelcetAll = SelcetAll + "      ,[Address] " + "\n";
                SelcetAll = SelcetAll + "      ,[City] " + "\n";
                SelcetAll = SelcetAll + "      ,[Region] " + "\n";
                SelcetAll = SelcetAll + "      ,[PostalCode] " + "\n";
                SelcetAll = SelcetAll + "      ,[Country] " + "\n";
                SelcetAll = SelcetAll + "      ,[Phone] " + "\n";
                SelcetAll = SelcetAll + "      ,[Fax] " + "\n";
                SelcetAll = SelcetAll + "  FROM [dbo].[Customers]";

                var cliente = conexion.Query<Customers>(SelcetAll).ToList();
                return cliente;
            }
        }
    }
}
