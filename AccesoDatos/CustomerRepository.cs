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

        public Customers ObtenerPorID(string id)
        {

            using (var conexion = DataBase.GetSqlConnection())
            {

                String selectPorID = "";
                selectPorID = selectPorID + "SELECT [CustomerID] " + "\n";
                selectPorID = selectPorID + "      ,[CompanyName] " + "\n";
                selectPorID = selectPorID + "      ,[ContactName] " + "\n";
                selectPorID = selectPorID + "      ,[ContactTitle] " + "\n";
                selectPorID = selectPorID + "      ,[Address] " + "\n";
                selectPorID = selectPorID + "      ,[City] " + "\n";
                selectPorID = selectPorID + "      ,[Region] " + "\n";
                selectPorID = selectPorID + "      ,[PostalCode] " + "\n";
                selectPorID = selectPorID + "      ,[Country] " + "\n";
                selectPorID = selectPorID + "      ,[Phone] " + "\n";
                selectPorID = selectPorID + "      ,[Fax] " + "\n";
                selectPorID = selectPorID + "  FROM [dbo].[Customers] " + "\n";
                selectPorID = selectPorID + "  WHERE CustomerID = @CustomerID";

                var Cliente = conexion.QueryFirstOrDefault<Customers>(selectPorID, new { CustomerID = id });
                return Cliente;
            }

        }
    }
}
